using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerScript : MonoBehaviour
{
    public float health = 50;
    public float moveSpeed;
    public float jumpStrength;
    public float wallJumpStrength;
    private Rigidbody2D playerRb;
    public bool isOnGround = true;
    private BoxCollider2D playerBox;
    public bool usedDoubleJump = false;
    public float doubleJumpStrength = 5;
    public bool ableToWallJumpLeft = false;
    public bool ableToWallJumpRight = false;
    public float wallJumpTime;
    public float wallJumpStunTime = 0.5f;
    public float resistWallJumpForce;
    public bool wallJumpedLeft = false;
    public bool wallJumpedRight = false;
    public float bulletDamage = 1;
    PhotonView view;

    // Start is called before the first frame update
    void Start()
    {
        view = gameObject.GetComponent<PhotonView>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        playerBox = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Jumping, Double Jumping, Wall Jumping
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isOnGround)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        playerRb.velocity = new Vector2(0, 0);
                        playerRb.AddForce(Vector2.up * (1.5f * jumpStrength), ForceMode2D.Impulse);
                        isOnGround = false;
                    }
                    else
                    {
                        playerRb.velocity = new Vector2(0, 0);
                        playerRb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
                        isOnGround = false;
                    }
                }
                else if (!isOnGround)
                {

                    if (ableToWallJumpRight)
                    {
                        playerRb.velocity = new Vector2(0, 0);
                        playerRb.AddForce(Vector2.left * wallJumpStrength, ForceMode2D.Impulse);
                        playerRb.AddForce(Vector2.up * wallJumpStrength * .75f, ForceMode2D.Impulse);
                        usedDoubleJump = false;
                        wallJumpedRight = true;
                        wallJumpedLeft = false;
                        wallJumpTime = Time.time;
                    }

                    else if (ableToWallJumpLeft)
                    {
                        playerRb.velocity = new Vector2(0, 0);
                        playerRb.AddForce(Vector2.right * wallJumpStrength, ForceMode2D.Impulse);
                        playerRb.AddForce(Vector2.up * wallJumpStrength * .75f, ForceMode2D.Impulse);
                        usedDoubleJump = false;
                        wallJumpedLeft = true;
                        wallJumpedRight = false;
                        wallJumpTime = Time.time;
                    }

                    else if (!usedDoubleJump)
                    {
                        usedDoubleJump = true;
                        playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
                        playerRb.AddForce(Vector2.up * doubleJumpStrength, ForceMode2D.Impulse);
                    }
                }
            }

            // Wall Jumping's Stun Effect so you can't run into the wall and keep jumping forever.

            if (Time.time > wallJumpTime + wallJumpStunTime)
            {
                if (wallJumpedLeft)
                {
                    wallJumpedLeft = false;

                }
                if (wallJumpedRight)
                {
                    wallJumpedRight = false;

                }
            }

            // Left Right Movement 

            if (Input.GetKey(KeyCode.A))
            {
                if (!wallJumpedLeft)
                {
                    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (!wallJumpedRight)
                {
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                }
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
    }
    
}
