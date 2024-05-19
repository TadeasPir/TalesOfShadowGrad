using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThirdPersonMove : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 moveDirection = Vector3.zero;
    public float moveSpeed = 6.0f;
    public Transform cam;
    private float smoothTurnVelocity;
    public float smoothTurnTime = 0.1f;
    public float jumpSpeed = 8.0f;
    public float gravity = -9.81f;

    private Vector3 moveDir;

    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    private bool isGrounded;
    private float vel;




    Vector3 velocity;

    [Header("Anim")]
    [SerializeField]
     Animator animator;

   
    void Start()
    {
       
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;
        }
       
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            moveDir = jumpSpeed *  Vector3.up;
            controller.Move(moveDir.normalized  * Time.deltaTime );
        }
        
        if (moveDirection.magnitude >= 0.1f) 
        {



            
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle,ref smoothTurnVelocity,smoothTurnTime);


             moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
           
            transform.rotation = Quaternion.Euler(0, angle, 0);



            vel = moveDirection.magnitude;
            if (Input.GetButton("Sprint"))
            {
                vel = vel * 1.5f;

                controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime * 2.0f);
              
                
            }
            else 
            {
                
                controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
                
            }

            Debug.Log(vel);

            animator.SetFloat("Velocity", vel);
        }
        



    }
}
