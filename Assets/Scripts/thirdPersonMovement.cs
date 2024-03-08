using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class thirdPersonMovement : MonoBehaviour
{
    //Essentials
    public Transform cam;
    CharacterController characterController;
    float turnSmoothTime = .1f;
    float turnSmoothVelocity;
    Animator anim;

    //Movement
    Vector2 movement;
    public float walkSpeed;
    public float sprintSpeed;
    bool sprinting;
    private float trueSpeed;

    //Jumping
    public float JumpHeight;
    public float gravity;
    bool isGrounded;
    Vector3 velocity;

    void Start()
    {
        trueSpeed = walkSpeed;
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, .1f, 1);
        anim.SetBool("isGrounded", isGrounded);

        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -1;
        }

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

        anim.transform.localPosition = Vector3.zero;
        anim.transform.localEulerAngles = Vector3.zero;
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if (direction.magnitude >= 0.1f) 
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(direction * trueSpeed * Time.deltaTime);
            if(sprinting == true)
            {
                anim.SetFloat("speed", 2);
            }
            else
            {
                anim.SetFloat("speed", 1);
            }

        }
        else
        {
            anim.SetFloat("speed", 0);
        }
        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //Debug.Log("JUMP"); 
            velocity.y += Mathf.Sqrt((JumpHeight * 10) * -2f * gravity);
        }

        if(velocity.y > -20)
        {
            velocity.y += (gravity * 10) * Time.deltaTime;
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}
