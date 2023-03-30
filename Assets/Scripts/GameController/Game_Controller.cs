using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Controller : MonoBehaviour
{
    public static Game_Controller Instance;

    public GameObject player;
    [HideInInspector]
    public  GameObject playerinstance;
    public GameObject enemy;
    public GameObject spike;
    public GameObject coin;
    public GameObject levelComplete;
   
    public GameObject levelFailedPanel;
    public Text score;
    public Text health;
    public Text playerName;
    public Text instruction;
    [HideInInspector]
    public int CurrentLevel;

    [HideInInspector] public bool isPlayerActive;

    [SerializeField] private PlayerData _playerData;

    public Levels[] level;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Start()
    {    

        Time.timeScale = 1;
        CurrentLevel = GameManager.instance.currentLevel;
        Debug.Log(CurrentLevel);
        
        LoadLevel();
        ActivateLevel();
        ResetLevel();
        PlayerName();

        isPlayerActive = true;

    }

    public void LoadLevel()
    {
        if (level.Length > 0 && CurrentLevel-1< level.Length &&   GameManager.instance.playerLives > 0)
        {
            
            health.text = "Health: " + GameManager.instance.playerLives;
            score.text = "Score: " + GameManager.instance.score;

            if (level[CurrentLevel - 1].enemySpawn.Length > 0)
            {
                for (int j = 0; j < level[CurrentLevel-1].enemySpawn.Length; j++)
                {
                    if (CurrentLevel == 1)
                    {
                       Instantiate(enemy, level[CurrentLevel-1].enemySpawn[j]);
                       Debug.Log(level[CurrentLevel-1].enemySpawn[j].gameObject);
                    }
                    else
                    {
                        Instantiate(enemy, level[CurrentLevel-1].enemySpawn[j]);
                    }
                }
            }

            if (level[CurrentLevel - 1].spikesSpawn.Length > 0)
            {
                for (int j = 0; j < level[CurrentLevel-1].spikesSpawn.Length; j++)
                {
                    if (CurrentLevel == 1)
                    {
                        Instantiate(spike, level[CurrentLevel-1].spikesSpawn[j]);

                    }
                    else
                    {
                        Instantiate(spike, level[CurrentLevel-1].spikesSpawn[j]);
                    }
                }
            }

            if (level[CurrentLevel-1].coinsSpawn.Length >0)
            {
                for (int j = 0; j < level[CurrentLevel-1].coinsSpawn.Length; j++)
                {
                    if (CurrentLevel == 1)
                    {
                        Instantiate(coin, level[CurrentLevel-1].coinsSpawn[j]);
                    }
                    else
                    {
                        Instantiate(coin, level[CurrentLevel-1].coinsSpawn[j]);
                    }
                }
            }
       
        }
        for (int i = 0; i < level.Length; i++)
        {
            // if (CurrentLevel == GameManager.instance.currentLevel && i == 0)
            // {
            //     //level[i].levelObject.SetActive(true);
            //     level[i].objective.SetActive(true);
            //     playerinstance= Instantiate(player, level[i].playerSpawn);
            //     ShowInstruction();
            //     for (int j = 0; j < level[i].enemySpawn.Length; j++)
            //     {
            //         Instantiate(enemy, level[i].enemySpawn[j]);
            //     }
            //     for (int j = 0; j < level[i].spikesSpawn.Length; j++)
            //     {
            //         Instantiate(spike, level[i].spikesSpawn[j]);
            //     }
            //     for (int j = 0; j < level[i].coinsSpawn.Length; j++)
            //     {
            //         Instantiate(coin, level[i].coinsSpawn[j]);
            //     }
            //     
            // }
            // if (CurrentLevel == GameManager.instance.currentLevel && i > 0)
            // {
            //     level[i].levelObject.SetActive(true);
            //     level[i-1].levelObject.SetActive(false);
            //     level[i].objective.SetActive(true);
            //     level[i-1].objective.SetActive(false);
            //     playerinstance=Instantiate(player, level[i].playerSpawn);
            //     ShowInstruction();
            //     for (int j = 0; j < level[i].enemySpawn.Length; j++)
            //     {
            //         Instantiate(enemy, level[i].enemySpawn[j]);
            //     }
            //     for (int j = 0; j < level[i].spikesSpawn.Length; j++)
            //     {
            //         Instantiate(spike, level[i].spikesSpawn[j]);
            //     }
            //     for (int j = 0; j < level[i].coinsSpawn.Length; j++)
            //     {
            //         Instantiate(coin, level[i].coinsSpawn[j]);
            //     }
            //     
            // }
        }
    }

    // Activate Current Level
    void ActivateLevel()
    {
        for (int i = 0; i < level.Length ; i++){
            if (i == CurrentLevel - 1){
                
                level [i].levelObject.SetActive (true);
                playerinstance = Instantiate(player, level[i].playerSpawn);
                ShowInstruction();
            } 
            else{
                level [i].levelObject.SetActive (false);
                // Destroy (level [i].playerSpawn.gameObject);
                    // Destroy (level [i].levelObject);
            }
        }
    }

    //Show Currant Level Text
    public void ShowInstruction()
    {
        instruction.text = level[CurrentLevel - 1].levelInstruction;

    }
    public void ResetLevel()
    {
        levelComplete.SetActive(false);
        levelFailedPanel.SetActive(false);
    }


    public void LevelComplete()
    {
    
        levelComplete.SetActive(true);
        Time.timeScale = 0;
        Destroy(playerinstance);

    }

    //Level Failed Panel Show on Health = 0
    public void LevelFailed()
    {

        if (GameManager.instance.playerLives > 1)
        {       
            GameManager.instance.playerLives--;
            Health();
        }
        else
        {
            isPlayerActive = false;
            levelFailedPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void Exit()
    {
        Debug.Log("Game Exit");
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("MainMenu");
    }

    //GoTo Next Level
    public void NextLevel()
    {
        if (CurrentLevel < level.Length)
        {
            GameManager.instance.currentLevel++;
            isPlayerActive = false;
            DestroyItems();
            Start();
        }
        else
        {

        }
    }

    //Show Score
    public void Score()
    {
        score.text = "Score: " + GameManager.instance.score;

    }

    //Show Health 
    public void Health()
    {
        health.text = "Health: " + GameManager.instance.playerLives;

    } 
    public void PlayerName()
    {
        playerName.text = "    Player Name: " + _playerData.playerData[CurrentLevel-1].playerName;

    }
    

    public void DestroyItems()
    {
        GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var item in Enemy)
        {
            Destroy(item);
        }
        GameObject[] Coin = GameObject.FindGameObjectsWithTag("Coin");
        foreach (var item in Coin)
        {
            Destroy(item);
        }
        GameObject[] Spike = GameObject.FindGameObjectsWithTag("Spike");
        foreach (var item in Spike)
        {
            Destroy(item);
        }
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
