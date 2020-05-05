using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
   
    Vector3 newPos;
    [SerializeField] float boostForce = 10;
    private float gravity = 0.0f;
    Vector3 moveVector;

    public float Velocity { get; private set; }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        BoostUp();


    }
    public void Gravity()                                  //add "artificial gravity" so that the controller is touching the ground
    {

        Velocity -= gravity * Time.deltaTime;      //start making the velocity negative 


        BoostUp();                              //jump

        moveVector.y = Velocity * Time.deltaTime;   //when spacebar is pressed it launches you into the air, and gravity will bring you down
    }
    void BoostUp()
    {
        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
        Move moveScript = thePlayer.GetComponent<Move>();
        moveScript.Velocity = boostForce;                                         //jump
        


        print("Boost");
        //playerScript.Force = 100;



    }

}
