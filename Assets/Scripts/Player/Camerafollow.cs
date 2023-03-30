using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject playerPrefab;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    private Transform playerTransform;

    void Start()
    {
        // Instantiate the player object
        GameObject playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        playerTransform = playerObject.transform;
    }

    void LateUpdate()
    {
        // Smoothly move the camera to follow the player
        Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
    
    
    
    
    
    
    
    // public Transform target;
    // // public Transform Game_Controller;
    // public float smoothing = 5f;
    //
    // Vector3 offset;
    //
    //
    //
    //
    // void Start()
    // {
    //     // target = Game_Controller.instance.playerinstance.transform;
    //
    //     offset = transform.position - target.position;
    //     Debug.Log(target);
    // }
    //
    // void FixedUpdate()
    // {
    //     Vector3 targetCamPos = target.position + offset;
    //     transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    // }
}
