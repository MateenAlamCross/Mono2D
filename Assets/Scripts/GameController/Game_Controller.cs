using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject levelComplete;
    public GameObject levelFailed;
    public Text instruction;
    [HideInInspector]
    public int CurrentLevel;
    public Levels[] level;

    private void Start()
    {
        Time.timeScale = 1;
        CurrentLevel = GameManager.instance.currentLevel;
        
        ResetLevel();
        LoadLevel();


    }


    public void LoadLevel()
    {
        instruction.text = "Level " + level[CurrentLevel - 1].levelInstruction;
    }

    public void spawnEnemies()
    {
        
    }

    public void ResetLevel()
    {
        levelComplete.SetActive(false);
        levelFailed.SetActive(false);
    }


    public void LevelComplete()
    {
        levelComplete.SetActive(true);
        Time.timeScale = 0;

    }

    public void LevelFailed()
    {
        levelFailed.SetActive(true);
        Time.timeScale = 0;

    }

}

[System.Serializable]
public class Levels
{
    public GameObject levelObject;
    public Transform playerSpawn;
    public GameObject objective;
    public Transform[] enemySpawn;
    public Transform[] spikesSpawn;
    public Transform[] coinsSpawn;
    [Multiline]
    public string levelInstruction;
}
