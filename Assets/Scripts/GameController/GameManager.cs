using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLevel = 1;
    [HideInInspector]
    public int playerLives ;
    public int score;
    [SerializeField] private PlayerData _playerData;
    
    private GameManager() { }

    private void Awake()
    {
        playerLives = _playerData.playerData[0].playerHealth;
        
        if (instance == null)
        {
            instance = this;
        }
        
    }

}
