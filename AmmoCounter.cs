using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    // TODO: Implement changes for when more than one weapon exists in the game.
    public Image ammoRatio;
    public Text ratioText;

    // Start is called before the first frame update
    void Start()
    {
        statUpdate(35, 35); // Hardcodes in the base ammo amounts. I don't know how to set these from Weapon.cs
    }

    // Update is called once per frame

    public void statUpdate(float currAmmo, int maxAmmo) {
        // this script is accessed by Weapon.cs any time the weapon is fired.
        float ratio = currAmmo / maxAmmo;
        Debug.Log("Ammo ratio: " + ratio);
        ammoRatio.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = currAmmo.ToString() + '/' + maxAmmo.ToString();
    }
}
