using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      




    }
    public void OnTriggerStay(Collider collider)
    {

        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");
        Health playerScript = thePlayer.GetComponent<Health>();
        playerScript.health += 10.0f * Time.deltaTime;
        print("Health is now" + thePlayer.GetComponent<Health>().health);
    }

}
