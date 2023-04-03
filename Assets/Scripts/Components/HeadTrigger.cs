using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrigger : MonoBehaviour
{

    public GameObject enemy;

    // private void OnCollisionEnter(Collision collision)
    // {
    //     Debug.Log("On Collision Enter for head hit"+collision.gameObject);
    //
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         Destroy(enemy);
    //         //Destroy(this);
    //         
    //         Debug.Log(this);
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = other.gameObject.GetComponent<Rigidbody>().velocity.normalized;
 
            other.gameObject.GetComponent<Rigidbody>().AddForce(direction*5);
            Destroy(enemy);
            //Destroy(this);
            
            Debug.Log(this);
        }    
    }
}
