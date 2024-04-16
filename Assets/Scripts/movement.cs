using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Transform cam;
    CharacterController characterController;
    float turnSmoothTime = .1f;
    float turnSmoothVelocity;
    Animator anim;

    Vector2 movements;
    public float walkSpeed;
    public float sprintSpeed;
    bool sprinting;
    float trueSpeed;

    public float jumpHeight;
    public float gravity;
    bool isGrounded;
    Vector3 velocity;

    void Start()
    {
        Time.timeScale = 1f;
        trueSpeed = walkSpeed;
        isGrounded = true;
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .1f, 1);
        anim.SetBool("isGrounded", isGrounded);
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(transform.position, .1f);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        movements = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movements.x, 0, movements.y).normalized;

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            trueSpeed = sprintSpeed;
            sprinting = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            trueSpeed = walkSpeed;
            sprinting = false;
        }

        if(direction.magnitude >= 0.1f) 
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDirection.normalized * trueSpeed * Time.deltaTime);
            if(sprinting == true)
            {
                anim.SetFloat("Speed", 2);
            }else
            {
                anim.SetFloat("Speed", 1);
            }
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
        if(Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2f * gravity);
        }

        if(velocity.y > -20)
        {
            velocity.y += (gravity * 10) * Time.deltaTime;
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}
