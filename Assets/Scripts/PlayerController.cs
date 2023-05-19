using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public SpriteRenderer Sr;
    public Animator playerAnim;
    public int jumpforce;
    public int moveSpeed;
    public float horizontalInput;
    public bool isOnGround = true;
    public int numberOfSus;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        Sr = gameObject.GetComponent<SpriteRenderer>();
        playerAnim = gameObject.GetComponent<Animator>();
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
            Sr.flipX = true;
        }
        else
        {
            Sr.flipX = false;
        }

        //check if player is moving
        if(horizontalInput != 0)
        {
            playerAnim.SetBool("IsRunning", true);
        }
        else
        {
            playerAnim.SetBool("IsRunning", false);
        }

        //jumping and check is player isonground
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        }


        if(Input.GetKeyDown(KeyCode.E))
        {
            if(numberOfSus >= 1)
            {
                playerAnim.SetTrigger("Eat");
                StartCoroutine(superJump());
            }
        }
    }
    public void Jump()
    {
        playerAnim.SetBool("IsOnGround", false);
        isOnGround = false;
        playerRb.AddForce(transform.up * jumpforce);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnim.SetBool("IsOnGround", true);
        }
    }
    IEnumerator superJump()
    {
        numberOfSus--;
        jumpforce = 600;
        yield return new WaitForSeconds(5);
        jumpforce = 350;
    }
}
