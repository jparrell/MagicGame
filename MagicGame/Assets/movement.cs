using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
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
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);
        if (Input.GetButton("Jump") && groundedPlayer)
        {
            playerVelocity.y += jumpHeight;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
