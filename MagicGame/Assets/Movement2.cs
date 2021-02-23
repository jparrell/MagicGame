using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    //player stats
    private float playerSpeed = 50f;
    private float jumpHeight = 1f;
    private float jumpCharge = 2f;

    //dash stats
    private float dashSpeed = 7f;
    private float dashTimer = 0f;
    private float dashPause = 0f;
    private bool wave = false;
    private Vector3 airdodge;
    private float dodgeLength = 10f;
    private int l = 0;

    //initialization
    private bool groundedPlayer;
    private float horizontal = 0f;
    private float vertical = 0f;
    public bool facingRight = true;

    //world properties
    public float gravityValue = -5f;
    public float frictionTime = 0.1f;
    private float friction = .95f;
    private float frictionTimer = 0.0f;
    private float lag = 0f;
    private bool air;





    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = false;

        //timers for movement
        lag += Time.deltaTime;
        frictionTimer += Time.deltaTime;
        dashPause -= Time.deltaTime;
        dashTimer -= Time.deltaTime;

        //grounded check
        Vector3 dwn = new Vector3(0, -1, 0);
        Vector3 pos = new Vector3(0f, -0.5f, 0f);
        if (Physics.Raycast(transform.position, dwn, 1f))
        {
            groundedPlayer = true;
        }
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            lag = (-1 / 60);
        }
        if (groundedPlayer)
        {
            dashTimer = 0;
            jumpCharge = 2;
        }
        if (groundedPlayer == false && air == false)
        {
            air = true;
            jumpCharge -= 1;
        }
        if (lag >= 0)
        {
            if (dashPause <= 0 && groundedPlayer)
            {
                playerVelocity.x = Input.GetAxisRaw("Horizontal");
            }
            if (Input.GetButtonDown("Jump") && jumpCharge >= 1)
            {
                playerVelocity.y = jumpHeight;
                jumpCharge -= 1f;
            }
            if (Input.GetButtonDown("Dash") && dashTimer <= 0 & !groundedPlayer)
            {
                playerVelocity.x = 0f;
                playerVelocity.y = 0f;

                playerVelocity.x = (Input.GetAxisRaw("Horizontal") * dashSpeed);
                playerVelocity.y = (Input.GetAxisRaw("Vertical") * dashSpeed);
                StartCoroutine("wavedash");
                dashPause = 0.2f;
                wave = true;

            }
        }
        if (playerVelocity.x < 0 && facingRight || playerVelocity.x > 0 && !facingRight)
        {
            Flip();
        }
        if (groundedPlayer)
        {
            if (dashPause > 0f && dashPause <= 0.4f && wave)
            {
                int direction = 1;
                if (playerVelocity.x < 0)
                {
                    direction = -1;
                }
                playerVelocity.x = Mathf.Sqrt((playerVelocity.x) * playerVelocity.x + playerVelocity.y * playerVelocity.y) * direction;
                Debug.Log(playerVelocity.x);
                wave = false;

            }
        }
        if (groundedPlayer == false && dashPause < 0)
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }
        if (dashPause < 0f)
        {
            controller.Move(playerVelocity * Time.deltaTime * playerSpeed);
        }
        if (dashPause > 0f && dashPause < .01f && wave)
        {
            playerVelocity.x = 0f;
            playerVelocity.y = 0f;
        }
    }
    IEnumerator wavedash()
    {
        for (l = 0; l < 100; l++)
        {
            controller.Move(playerVelocity * dashSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
