using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Controller : MonoBehaviour
{
    public static Game_Controller instance;

    public GameObject player;
    public GameObject playerinstance;
    public GameObject enemy;
    public GameObject spike;
    public GameObject coin;
    public GameObject levelComplete;
    public GameObject levelFailed;
    public Text score;
    public Text health;
    public Text instruction;
    [HideInInspector]
    public int CurrentLevel;

    [SerializeField] private PlayerData _playerData;

    public Levels[] level;
    

    private void Start()
    {    

        Time.timeScale = 1;
        Debug.Log(CurrentLevel);
        Debug.Log(GameManager.instance.currentLevel);
        CurrentLevel = GameManager.instance.currentLevel;

        Debug.Log(CurrentLevel);

        ResetLevel();
        LoadLevel();

    }

    private Game_Controller() { }
	
    public static Game_Controller Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Game_Controller();
            }
            return instance;
        }
    }
    

    public void LoadLevel()
    {
        for (int i = 0; i < level.Length; i++)
        {
            if (CurrentLevel == GameManager.instance.currentLevel && i == 0)
            {
                level[i].levelObject.SetActive(true);
                level[i].objective.SetActive(true);
                playerinstance= Instantiate(player, level[i].playerSpawn);
                ShowInstruction();
                for (int j = 0; j < level[i].enemySpawn.Length; j++)
                {
                    Instantiate(enemy, level[i].enemySpawn[j]);
                }
                for (int j = 0; j < level[i].spikesSpawn.Length; j++)
                {
                    Instantiate(spike, level[i].spikesSpawn[j]);
                }
                for (int j = 0; j < level[i].coinsSpawn.Length; j++)
                {
                    Instantiate(coin, level[i].coinsSpawn[j]);
                }
                
            }
            if (CurrentLevel == GameManager.instance.currentLevel && i > 0)
            {
                level[i].levelObject.SetActive(true);
                level[i-1].levelObject.SetActive(false);
                level[i].objective.SetActive(true);
                level[i-1].objective.SetActive(false);
                playerinstance=Instantiate(player, level[i].playerSpawn);
                ShowInstruction();
                for (int j = 0; j < level[i].enemySpawn.Length; j++)
                {
                    Instantiate(enemy, level[i].enemySpawn[j]);
                }
                for (int j = 0; j < level[i].spikesSpawn.Length; j++)
                {
                    Instantiate(spike, level[i].spikesSpawn[j]);
                }
                for (int j = 0; j < level[i].coinsSpawn.Length; j++)
                {
                    Instantiate(coin, level[i].coinsSpawn[j]);
                }
                
            }
        }
    }

    public void ShowInstruction()
    {
        instruction.text = level[CurrentLevel - 1].levelInstruction;

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
