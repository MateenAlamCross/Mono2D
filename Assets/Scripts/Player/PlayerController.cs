using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Speed")]
    public float moveSpeed = 5f;
    [Header("Jump Force")]
    public float jumpForce = 7f;

    
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(horizontal*moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            // Debug.Log(collision.gameObject);

            // Debug.Log(Game_Controller.Instance.levelFailedPanel);
            // Game_Controller.Instance.levelFailedPanel.SetActive(true);
            // Game_Controller.Instance.LevelComplete();

            Game_Controller.Instance.LevelFailed();

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Game_Controller.Instance.LevelFailed();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Game_Controller.Instance.isPlayerActive = false;
            Game_Controller.Instance.LevelComplete();
        }
    }
}
