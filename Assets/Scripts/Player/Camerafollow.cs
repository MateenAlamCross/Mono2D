using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{ 
    private Transform target;
    // public Transform Game_Controller;
    public float smoothing = 5f;

    Vector3 offset;




    void Start()
    {
        target = Game_Controller.instance.playerinstance.transform;
        offset = transform.position - target.position;
        Debug.Log(target);
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
