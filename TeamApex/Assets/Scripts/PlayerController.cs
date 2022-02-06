using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    public CharacterController contrl;
    public Transform cam;

    // movement
    public float moveSpeed = 5f;
    public float jumpHeight = 2.5f;


    // smoothing 
    public float smoothTime = 0.1f;
    private float smoothVelocity;

    // gravity / ground check
     public float gravity = -9.81f;
     public float groundDistance = 0.4f;
     public Transform groundCheck;
     public LayerMask groundMask;
     bool isGrounded;
     public Vector3 velocity;

    void Update()
    {

         //jump
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("MainMenu");
        }

        //gravity
        velocity.y += gravity * Time.deltaTime;
        contrl.Move(velocity * Time.deltaTime);

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal,0f,vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0F, targetAngle, 0f) * Vector3.forward;

            contrl.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
