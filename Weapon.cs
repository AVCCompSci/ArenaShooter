using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera = null;

    [SerializeField] float range = 100f;


    public int maxAmmo = 35;
    public int currentAmmo = 35;
    public GameObject myAmmoCounter;
    AmmoCounter myAmmoCounterScript;
    float reloadFiringCooldown = 3;
    bool canReload = false;
    bool canShoot = true;

    private void Start()
    {
        myAmmoCounterScript = myAmmoCounter.GetComponent<AmmoCounter>();
    }
    RaycastHit enemyHit;

    // Update is called once per frame
    void Update()
    {
        
        Check();
        if(currentAmmo < maxAmmo)
        {
            this.canReload = true;
        }
        if (!canShoot)
        {
            Reload();
        }
        
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0 && canShoot)
        {
            Shoot();
        }
        else if (Input.GetButtonDown("Fire1") && currentAmmo == 0)
        {
            if (canReload)
            {
                Debug.Log("REEELOADIN");
                Reload();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            if (canReload)
            {
                Debug.Log("REEELOADIN");
                Reload();
            }
        }


    }

    private void Shoot()
    {
        if (!canShoot)
        {
            return;
        }
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out enemyHit, range);
        Debug.Log("I hit this thing: " + enemyHit.transform.name);
        currentAmmo--;
        myAmmoCounterScript.statUpdate(currentAmmo, maxAmmo);
        Debug.Log("I have this much max ammo: " + maxAmmo);
        Debug.Log("I have this much ammo: " + currentAmmo);
    }

    private void Reload()
    {
        // During this time, play some reload animation?
        this.canShoot = false;
        if (reloadFiringCooldown > 0)
        {
            reloadFiringCooldown -= Time.deltaTime;
        }
        if (reloadFiringCooldown < 0)
        {
            reloadFiringCooldown = 0;
        }
        if (reloadFiringCooldown == 0)
        {
            this.currentAmmo = this.maxAmmo;
            myAmmoCounterScript.statUpdate(currentAmmo, maxAmmo);
            this.canShoot = true;
            this.reloadFiringCooldown = 3;
            Debug.Log("Can shoot again.");
        }
        return;
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

    public int getMaxAmmo()
    {
        return this.maxAmmo;
    }

    public int getCurrAmmo()
    {
        return this.currentAmmo;
    }
}
