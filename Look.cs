using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    [SerializeField]
    private Transform player;                                           //reference to gameobject
    [SerializeField]                                                                
    
    private Transform look;                                                 //reference to gameobject


    private float speed = 3.5f;


    [SerializeField]
    private Vector2 limits = new Vector2(-75f, 90f);

    [SerializeField]
    private Vector2 Position;                                        // screen position
    [SerializeField]
    private Vector2 currentMouse;                                   //reference to where our mouse would be
   
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
       
        LookUpandDown();
    }
    void LookUpandDown()
    {
        currentMouse = new Vector2(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X")); //2d representation of mouse location
        Position.x = Mathf.Clamp(Position.x, limits.x, limits.y);                       //keep the value between some limits
        Position.x = Position.x + currentMouse.x * -speed;                                 //add the mouse inputs to position x
        Position.y = Position.y + currentMouse.y * speed;                                  //add the mouse inputs to position y

       
        //rotations
        look.localRotation = Quaternion.Euler(Position.x, 0, 0f);                      //local rotate the look root
        player.localRotation = Quaternion.Euler(0, Position.y, 0f);                    //local rotate the player root
        





    }
}
