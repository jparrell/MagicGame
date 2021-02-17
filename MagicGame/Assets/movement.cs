using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float dashSpeed = 2.0f;
    private float dashTimer= 0f;
    public float dashCD = 2.0f;
    private float timer = 0f;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 8.0f;
    public float gravityValue = -9.8f;
    private float horizontal = 0f;
    private float vertical = 0f;




    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        dashTimer = timer;
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
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
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += jumpHeight;
        }
        if (Input.GetButtonDown("Dash") && dashTimer > dashCD)
        {
            Debug.Log("gay");
            playerVelocity.x += (Input.GetAxisRaw("Horizontal") + dashSpeed);
            dashTimer = 0;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


    }
}
