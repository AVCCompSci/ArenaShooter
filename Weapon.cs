using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;

    [SerializeField] float range = 100f;



    private void Start()
    {

        

    }
    RaycastHit enemyHit;

    // Update is called once per frame
    void Update()
    {

        Check();

         if (Input.GetButtonDown("Fire1"))
        {
             Shoot();

        }


    }

    private void Shoot()
    {

        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out enemyHit, range);
        Debug.Log("I hit this thing: " + enemyHit.transform.name);

    }
    void Check()
    {
        Image reticle = GameObject.Find("reticle").GetComponent<Image>();
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out enemyHit, range) && enemyHit.transform.name == "damage")
        {
            
            reticle.color = Color.red;
        }
        else
        {
            reticle.color = Color.green;
        }
    }
}
