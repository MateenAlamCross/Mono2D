using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Trigger");
        // Debug.Log(other);
        GameManager.instance.score++;
        Destroy(gameObject);
        if (other.CompareTag("Player"))
        {
           
        }
    }
}
