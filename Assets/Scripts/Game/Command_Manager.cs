using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command_Manager : MonoBehaviour
{
    public static Command_Manager Instance;
    
    private List<Command> mainCommands = new List<Command>();
    private List<Command> functionCommands = new List<Command>();
    
    private Bot bot;
    
    [SerializeField] private GameObject commandContainer;
    [SerializeField] private Transform mainContainer;
    [SerializeField] private Transform functionContainer;
    
    private const int FUNCTION_COMMAND = 5;
    private const int MAX_COMMANDS_MAIN = 12;
    private const int MAX_COMMANDS_FUNCTION = 8;

    private bool isMain = true;
    private bool isFunction = false;

    enum Container
    {
        Main,
        Function
    }
    
    private void Start()
    {
        Instance = this;
    }
    public void AddCommand(Command command)
    {
        if (isMain && mainCommands.Count <= MAX_COMMANDS_MAIN)
        {
            mainCommands.Add(command);
            ShowCommandItem(command, mainContainer);
        }

        if (isFunction && functionCommands.Count <= MAX_COMMANDS_FUNCTION)
        {
            functionCommands.Add(command);
            ShowCommandItem(command, functionContainer);
        }
        
    }

    public void RemoveCommand(Command command)
    {
        mainCommands.Remove(command);
        //TODO : Don't show 
    }

    private void ShowCommandItem(Command command, Transform container)
    {
        GameObject commandPrefab = Instantiate(commandContainer, container);
        commandPrefab.GetComponent<Image>().sprite = command.icon;
    }

    public void OnRun()
    {
        GetBot();
        BreakFunctions();
        CommandBot();
    }

    void BreakFunctions()
    {
        for (int i = 0; i < mainCommands.Count; i++)
        {
            if (mainCommands[i].value == FUNCTION_COMMAND)
            {
                for (int j = 0; j < functionCommands.Count; j++)
                {
                    mainCommands.Insert(i + j, functionCommands[j]);
                }
                mainCommands.Remove(mainCommands[i + functionCommands.Count]);
            }
        }
    }
    

    private void CommandBot()
    {
        StartCoroutine(bot.Move(mainCommands));
    }

    private void GetBot()
    {
        bot = GameObject.Find("Bot").GetComponent<Bot>();

        if (bot == null)
            Debug.LogError("Bot Is Empty");
    }

    public void ClearCommandList()
    {
        mainCommands.Clear();
        foreach (Transform child in mainContainer) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void OnSelectContainer(int containerID)
    {
        switch (containerID)
        {
            case (int)Container.Main:
                isMain = true;
                isFunction = false;
                break;
            
            case (int)Container.Function:
                isMain = false;
                isFunction = true;
                break;
        }
    }

    public void SetContainers(int numberOfAvailableCommands)
    {
        if (numberOfAvailableCommands > 5)
        {
            functionContainer.gameObject.SetActive(true);
        }
        else
        {
            functionContainer.gameObject.SetActive(false);
        }
    }
}
