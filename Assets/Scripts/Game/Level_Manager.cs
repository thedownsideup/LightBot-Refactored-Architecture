using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    [SerializeField] List<Level> levels;
    [SerializeField] private int levelNumber = 0;
    private int numberOfLitBlocks = 0;
    private int numberOfLightableBlocks;

    private GameObject map;
    private UI_Manager uiManager;

    private void Awake()
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        DeleteLastLevel();
        InstantiateMap();
        numberOfLightableBlocks = levels[levelNumber].numberOfLightableBlocks;
        levelNumber++;
    }

    private void InstantiateMap()
    {
        map = levels[levelNumber].map;
        Instantiate(map);
        map.gameObject.SetActive(true);
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
            Debug.LogError("Level Manager Is Empty");
        }
    }

    private void DeleteLastLevel()
    {
        if (map != null)
        {
            map.SetActive(false); //Can I relocate the Bot that I have?
        }
    }
}
