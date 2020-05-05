using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostCounter : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 2;
    public Text counterText;

    bool isCooldown = true;
    
        
            


        
    
    void Update()
    {
        
        
            counterText.text = "Counter: " + GameObject.Find("Player").GetComponent<Move>().dashesRemaining;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isCooldown = true;
            }
            if (isCooldown)
            {

                imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;

                if (imageCooldown.fillAmount >= 1)
                {
                    imageCooldown.fillAmount = 0;
                    isCooldown = false;
                }
            }
        
    }






}
