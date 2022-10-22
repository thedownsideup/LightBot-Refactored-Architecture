using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Command_Manager : MonoBehaviour
{
    public static Command_Manager Instance;
    
    private List<CommandData> mainCommands = new List<CommandData>();
    private List<CommandData> functionCommands = new List<CommandData>();
    
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
    public void AddCommand(CommandData commandData)
    {
        if (isMain && mainCommands.Count <= MAX_COMMANDS_MAIN)
        {
            mainCommands.Add(commandData);
            ShowCommandItem(commandData, mainContainer);
        }

        else if (isFunction && functionCommands.Count <= MAX_COMMANDS_FUNCTION)
        {
            functionCommands.Add(commandData);
            ShowCommandItem(commandData, functionContainer);
        }
        
    }

    public void RemoveCommand(CommandData commandData)
    {
        if (mainCommands.Contains(commandData))
        {
            mainCommands.Remove(commandData);
        }

        else if (functionCommands.Contains(commandData))
        {
            functionCommands.Remove(commandData);
        }
    }

    private void ShowCommandItem(CommandData commandData, Transform container)
    {
        GameObject commandPrefab = Instantiate(commandContainer, container);
        commandPrefab.GetComponent<CommandController>().commandData = commandData;
        commandPrefab.GetComponent<Image>().sprite = commandData.Icon;
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
            if (mainCommands[i].Value == FUNCTION_COMMAND)
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
