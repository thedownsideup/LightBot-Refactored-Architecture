using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPick : MonoBehaviour
{
    private int levelNumber;
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadScene(int chosenLevelNumber)
    {
        levelNumber = chosenLevelNumber;
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        Level_Manager levelManager = GameObject.Find("Level_Manager").GetComponent<Level_Manager>();
        levelManager.levelNumber = levelNumber;
        levelManager.LoadNextLevel();
    }
}
