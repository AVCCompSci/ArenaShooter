using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private CharacterController Controller;
   
    public Vector3 dashDirection;
    public float dashDistance = 15;
    public float dashSpeed = 10;

    //member variables for movement
    public float speed = 5f;
    public float gravity = 20f;
    public float Velocity;                                      //you get it
    public float Force = 9.8f;
    public Vector3 moveVector;                                  //important variable to store 3 variable for 3 directions(xyz)
  
   
    void Update()
    {
        MovePlayer();
        Debug.Log(Velocity);
        if (Input.GetButtonDown("Fire2"))
        {
          
                Dash();
            
        }
    }
    void Dash()
    {
        dashDirection = transform.forward * dashSpeed;                          //get the forward vector and make it the direction(forward)         
        Controller.Move(Time.deltaTime * dashDistance * dashSpeed * dashDirection); //call the character move function and basically move it a big number

    }
    /*
    void DashBackWards()
    {
        dashDirection = -transform.forward * dashSpeed;                                 
        Controller.Move(Time.deltaTime * dashDistance * dashSpeed * dashDirection);

    }
    */
    void Awake()                                                //get a reference to the character controller on script load
    {
        Controller = GetComponent<CharacterController>(); 
    }

    void MovePlayer()
    {
        
        //declare the move variable 
        moveVector = new Vector3(Input.GetAxis("Horizontal"),0f,Input.GetAxis("Vertical"));

        moveVector = transform.TransformDirection(moveVector);     //move from local to world space(go in the direction you are looking        
        moveVector *= speed * Time.deltaTime;                      //make it a constant speed
        Gravity();
        Controller.Move(moveVector);                               //move bro                      
        

    } 

    void Gravity()                                  //add "artificial gravity" so that the controller is touching the ground
    {

        Velocity -= gravity * Time.deltaTime;      //start making the valocity negative 

        
        Jump();                              //jump

        moveVector.y = Velocity * Time.deltaTime;   //when spacebar is pressed it launches you into the air, and gravity will bring you down
    }
   
        void Jump()
        {

            if (Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) //if you press space bar you
            {
                     Velocity = Force;                                         //jump
            }

        }

} 

