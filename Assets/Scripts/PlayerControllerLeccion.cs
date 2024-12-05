using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerJumpForce = 20f;
    public Sprite[] walkSprites;
    private float playerSpeed = 5f;
    private int walkIndex = 0;


    private Rigidbody2D myrigidbody2D;
    private SpriteRenderer mySpriteRenderer;

    void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoroutine());

        myrigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, playerJumpForce);
        }
        myrigidbody2D.velocity = new Vector2(playerSpeed, myrigidbody2D.velocity.y);
    }
    
    IEnumerator WalkCoroutine()
    {
        while (true)
        {
            if (transform.position.y < -6)
            {
                Application.Quit();
                UnityEditor.EditorApplication.isPlaying = false;
            }
            walkIndex = (walkIndex + 1) % walkSprites.Length;
            mySpriteRenderer.sprite = walkSprites[walkIndex];
            yield return new WaitForSeconds(0.1f);
        }
    }

}