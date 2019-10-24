using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posistion = transform.position;                  //make a new vector variable and store the current x,y,z
        float newPos = Mathf.Sin(Time.time * 5f);              //make a float variable to store the sin values 
        transform.position = new Vector3(.0f, newPos, .0f) * 1.5f; //set the new position
        


    }
}
