using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]

[System.Serializable]
public class PlayerData : ScriptableObject
{
    // [SerializeField] public List<Player_data> playerData;
    [SerializeField] public Player_data[] playerData;
}


[System.Serializable]

public class Player_data
{
    public string playerName;
    public int playerLevel;
    public int playerHealth = 3;
}

