using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // public GameObject player;
    //
    // private NavMeshAgent navMeshAgent;
    // public Transform playerTransform;
    // public GameObject player;
    public float moveSpeed = 5f;
    public float detectionRange = 10f;

    private Rigidbody rb;

    private void Start()
    {
        // navMeshAgent = GetComponent<NavMeshAgent>();
        // navMeshAgent.destination = player.transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Debug.Log(Game_Controller.Instance.level[Game_Controller.Instance.CurrentLevel-1].playerSpawn.gameObject.transform.position);

        if (Game_Controller.Instance.isPlayerActive)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, Game_Controller.Instance.playerinstance.transform.position);

            // distanceToPlayer -= 5;
            // Debug.Log(distanceToPlayer-2);
            if (distanceToPlayer <= detectionRange)
            {
                // Vector2 direction = (playerTransform.position - transform.position).normalized;
                Vector2 direction = (Game_Controller.Instance.playerinstance.transform.position - transform.position).normalized;
                rb.velocity = direction * moveSpeed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
        // float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        //
        // if (distanceToPlayer > navMeshAgent.stoppingDistance)
        // {
        //     navMeshAgent.destination = player.transform.position;
        // }
    }

}
