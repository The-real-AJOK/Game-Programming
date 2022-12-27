using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementComponent : MonoBehaviour
{
    // private CharacterController controller;
    // private Vector3 playerVelocity;
    // private bool groundedPlayer;
    // private float playerSpeed = 2.0f;
    // private float jumpHeight = 1.0f;
    // private float gravityValue = -9.81f;
    private Rigidbody rigidbody;

    float distToGround;

    private void Start()
    {
        // controller = gameObject.AddComponent<CharacterController>();
        var rigidbody = this.gameObject.AddComponent<Rigidbody>();
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey("a")) transform.Translate(-0.5f * Time.deltaTime, 0, 0);
        if (Input.GetKey("w")) transform.Translate(0, 0, 0.5f * Time.deltaTime);
        if (Input.GetKey("s")) transform.Translate(0, 0, -0.5f * Time.deltaTime);
        if (Input.GetKey("d")) transform.Translate(0.5f * Time.deltaTime, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // transform.Translate(0, 10f * Time.deltaTime, 0);
            // rigidbody.AddForce(Vector3.up * 5);
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 2.5f, rigidbody.velocity.z);
        }
        // groundedPlayer = controller.isGrounded;
        // if (groundedPlayer && playerVelocity.y < 0f)
        // {
        //     playerVelocity.y = 0f;
        // }

        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // controller.Move(move * Time.deltaTime * playerSpeed);

        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }

        // // Changes the height position of the player..
        // if (Input.GetButtonDown("Jump") && groundedPlayer)
        // {
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        // }

        // playerVelocity.y += gravityValue * Time.deltaTime;
        // controller.Move(playerVelocity * Time.deltaTime);
    }
}
