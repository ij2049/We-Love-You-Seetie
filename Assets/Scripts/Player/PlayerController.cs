using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rigidBody;

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void FixedUpdate()
    {
        // Player Movement
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void PlayerMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
}
