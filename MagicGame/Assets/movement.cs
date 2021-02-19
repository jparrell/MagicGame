using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    //player stats
    public float playerSpeed = 1.0f;
    public float jumpHeight = 8.0f;

    //dash stats
    public float dashSpeed = 5f;
    private float dashTimer= 0f;
    public float dashCD = 2.0f;
    private float dashPause = 0f;

    //initialization
    private bool groundedPlayer;
    private float horizontal = 0f;
    private float vertical = 0f;

    //world properties
    public float gravityValue = -15f;
    public float frictionTime = 0.1f;
    private float friction = .95f;
    private float frictionTimer = 0.0f;


   


    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        frictionTimer += Time.deltaTime;
        dashPause -= Time.deltaTime;
        dashTimer -= Time.deltaTime;
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -1.0f;
        }
        /*     if (Input.GetButton("Horizontal"))
               {
                   horizontal += -1;
                   if (horizontal <-1)
                   {
                       horizontal = -1;
                   }
               }
               if (Input.GetButton("+Horizontal"))
               {
                   horizontal += 1;
                   if (horizontal > 1)
                   {
                       horizontal = 1;
                   }
               }
               if (Input.GetButton("+Vertical"))
               {
                   vertical += 1;
                   if (vertical > 1)
                   {
                       vertical = 1;
                   }
               }
               if (Input.GetButton("-Vertical"))
               {
                   vertical += -1;
                   if (vertical < -1)
                   {
                       vertical = -1;
                   }
               }*/
        // Debug.Log(dashTimer);
     //   if (Input.GetAxisR("Horizontal") )
        if (groundedPlayer)
        {
            dashTimer = 0;
            Debug.Log(playerVelocity.y);
        }
        if (dashPause <= 0 && groundedPlayer)
        {
            playerVelocity.x += Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += jumpHeight;
        }
        if (Input.GetButtonDown("Dash") &! groundedPlayer && dashTimer <= 0)
        {
            playerVelocity.x = 0f;
            playerVelocity.y = 0f;
            playerVelocity.x += (Input.GetAxisRaw("Horizontal") * dashSpeed);
            playerVelocity.y = (Input.GetAxisRaw("Vertical") * dashSpeed);
            dashTimer = 0;
            dashPause = 0.5f;
        }
        if (groundedPlayer && dashPause > 0f && dashPause <= 0.5f)
        {
            playerVelocity.x = Mathf.Sqrt(Mathf.Abs(playerVelocity.x)*playerVelocity.x + playerVelocity.y * playerVelocity.y);
            playerVelocity.y = -0.1f;
            Debug.Log(playerVelocity.y);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime * playerSpeed);
        //  controller.Move(playerVelocity * Time.deltaTime);
        if (frictionTimer > frictionTime)
        {
            if (groundedPlayer)
            {
                playerVelocity.x *= friction;
            }
        }


    }
}
