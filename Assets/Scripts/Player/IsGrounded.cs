using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public Transform groundCheck;

    bool isGrounded;

    void Update()
    {
        // groundCheck = Game_Controller.Instance.playerinstance;
        // Check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded)
        {
            // Player is on the ground
            Debug.Log("Player is on the ground");
        }
        else
        {
            // Player is in the air
            Debug.Log("Player is in the air");
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a sphere around the ground check position in the editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}