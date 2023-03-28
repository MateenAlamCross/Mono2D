using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int currentLevel = 1;
    public int playerLives = 3;
    public int score;

    
    private GameManager() { }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

}
