﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartMovement : MonoBehaviour
{
    private Vector2 movementFactor;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        movementFactor = new Vector2(10f, 0);
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movementFactor * Time.fixedDeltaTime);
        Invoke("destroyDart", 4f);
    }

    private void destroyDart()
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("destroyDart",0.2f);
            LivesScore.instance.ChangeScore(-1);
        }
    }
}