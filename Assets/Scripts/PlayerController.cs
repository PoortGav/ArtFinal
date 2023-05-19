using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public SpriteRenderer Sr;
    public int jumpforce;
    public int moveSpeed;
    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        Sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //moving
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed * horizontalInput);

        //check the direction the player is running
        if(horizontalInput < 0f)
        {

        }


        //jumping
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    public void Jump()
    {
        playerRb.AddForce(transform.up * jumpforce);
        Debug.Log("Jumped");
    }
}
