using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    CharacterController controller;

    Vector2 finalVelocity;

    Vector2 xVelocity;
    float xspeed = 5;

    Vector2 yVelocity;

    // variaveis do pulo
    float maxHeight = 2f;
    float jumpSpeed = 3;
    float timeToPeak = 0.3f;

    float gravity;

    void Start()
    {
        controller = GetComponent<CharacterController>(); 

        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);

        jumpSpeed = gravity * timeToPeak;
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        
        xVelocity = xspeed * xInput * Vector2.right; // (1, 0)

        yVelocity += gravity * Time.deltaTime * Vector2.down;
        if(controller.isGrounded) {
            yVelocity = Vector2.down;

        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded) {
            yVelocity = jumpSpeed * Vector2.up;
            }

        finalVelocity = xVelocity + yVelocity;

        controller.Move(finalVelocity * Time.deltaTime);

    }
}
