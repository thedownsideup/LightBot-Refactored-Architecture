using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] List<Level> levels;
    public int levelNumber = 0;
    private int numberOfLitBlocks = 0;
    private int numberOfLightableBlocks;

    private GameObject map;
    
    private UI_Manager uiManager;
    private Command_Manager commandManager;
    [SerializeField] private CommandButtonHolder commandHolder;
    
    public void LoadNextLevel()
    {
        DeleteLastLevel();
        InstantiateMap();
        numberOfLightableBlocks = levels[levelNumber].numberOfLightableBlocks;
        commandHolder.SetButtons(levels[levelNumber].numberOfAvailableCommands);
        commandManager.SetContainers(levels[levelNumber].numberOfAvailableCommands);
        levelNumber++;
    }

    private void InstantiateMap()
    {
        map = levels[levelNumber].map;
        Instantiate(map, transform, true);
    }

    public void CountLitBlocks()
    {
        numberOfLitBlocks++;
        CheckIfLevelOver();
    }

    private void CheckIfLevelOver()
    {
        if (numberOfLightableBlocks == numberOfLitBlocks)
        {
            GetUIManager();
            uiManager.LevelOver();
        }
    }

    private void GetUIManager()
    {
        uiManager = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        if (uiManager == null)
        {
            Debug.LogError("UI Manager Is Empty");
        }
    }
    
    private void GetCommandManager()
    {
        commandManager = GameObject.Find("Command_Manager").GetComponent<Command_Manager>();
        if (commandManager == null)
        {
            Debug.LogError("Command Manager Is Empty");
        }
    }

    private void DeleteLastLevel()
    {
        GetCommandManager();
        commandManager.ClearCommandList();
        
        if (map != null)
        {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
        }
        numberOfLitBlocks = 0;
    }
}
