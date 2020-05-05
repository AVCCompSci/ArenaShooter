using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  
    

    public Image CurrentHealthbar;
    public Text ratioText;
    

    private float maxHealth = 150;
   
    public void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        float ratio = GameObject.Find("Player").GetComponent<Health>().health / maxHealth;
        CurrentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString("0") + '%';
        if(GameObject.Find("Player").GetComponent<Health>().health < 0 )
        {
            GameObject.Find("Player").GetComponent<Health>().health = 0;
            Debug.Log("Dead!");
        }
        if (GameObject.Find("Player").GetComponent<Health>().health > maxHealth)
        {
            GameObject.Find("Player").GetComponent<Health>().health = maxHealth;
            
        }
    }
}
