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

    private int count = 2;
    private bool isGround;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        Debug.Log("Ground Check" + isGround);

        if (Input.GetButtonDown("Jump")  && isGround)
        {

            rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            isGround = false;
            
            
        }

        if (isGround)
        {
            rb.velocity = new Vector3(horizontal*moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector3(horizontal*moveSpeed/2, rb.velocity.y);

        }

    }

    void Jump()
    {

        rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.LogError("OnCollision" + collision.gameObject.name.ToString());
        // if (collision.gameObject.layer == LayerMask.GetMask("EnemyHead"))
        // {
        //     Destroy(collision.gameObject);
        // }
        // Debug.Log("Object colliding with="+collision.gameObject.name);
        
        if (collision.gameObject.CompareTag("Spike"))
        {
            Game_Controller.Instance.levelFailEvent.Invoke();
            isGround = true;

            //Game_Controller.Instance.LevelFailed();
        }
        else
        {
            isGround = false;

        }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hited a enemy");
            Vector3 direction = rb.velocity.normalized;
            rb.AddForce(direction*(jumpForce)/2);
            Game_Controller.Instance.levelFailEvent.Invoke();

            // Game_Controller.Instance.LevelFailed();
        }
        
        if (collision.gameObject.CompareTag("Finish"))
        {
            Game_Controller.Instance.isPlayerActive = false;
            Game_Controller.Instance.levelCompleteEvent.Invoke();
            
            // Game_Controller.Instance.LevelComplete();

        }
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Debug.Log(count);
            // count = 2;
            isGround = true;
        }
    }
}
