using System.Collections;
using System.Collections.Generic;
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
}
