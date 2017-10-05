using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireGrenade : MonoBehaviour
{

    public Transform barrelEndLeft;
    public Transform barrelEndRight;
    public GameObject bullet;
    public Text text;
    bool rightArm = false;
    int ammo = 5;

    bool used = false;
    bool firstActivation = true;
    bool firstActivationInGame = true;
    bool cooldown = false;

    float secondaryWeaponCooldown = 3.0f;
    float secondaryWeaponUseTime = 5.0f;

    float useStamp;
    float secondaryWeaponCooldownStamp;

    void Update()
    {
        text.text = "Ammo: " + ammo;
    }

    public void PrimaryFire()
    {
        if (ammo > 0)
        {
            GameObject projectile = Instantiate(bullet);
            if (rightArm)
            {
                projectile.transform.position = barrelEndRight.position;
                rightArm = false;
            }
            else
            {
                projectile.transform.position = barrelEndLeft.position;
                rightArm = true;
            }
            projectile.transform.rotation = transform.rotation;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 70);
            ammo--;
            GetComponent<AudioSource>().Play();
        }
    }

    public void SecondaryFire()
    {
        if (used)
        {
            useStamp = Time.time;
            used = false;
        }

        if ((Time.time < useStamp + secondaryWeaponUseTime || firstActivationInGame) && !cooldown)
        {
            GameObject projectileRight = Instantiate(bullet);
            GameObject projectileLeft = Instantiate(bullet);
            projectileRight.transform.position = barrelEndRight.position;
            projectileLeft.transform.position = barrelEndLeft.position;
            projectileRight.transform.rotation = transform.rotation;
            projectileLeft.transform.rotation = transform.rotation;
            Rigidbody rbR = projectileRight.GetComponent<Rigidbody>();
            Rigidbody rbL = projectileLeft.GetComponent<Rigidbody>();
            rbR.AddForce(transform.forward * 70);
            rbL.AddForce(transform.forward * 70);
            firstActivationInGame = false;
            if (!used && firstActivation)
            {
                used = true;
                firstActivation = false;
            }
        }
        else if (Time.time > useStamp + secondaryWeaponUseTime && !cooldown)
        {
            cooldown = true;
            secondaryWeaponCooldownStamp = Time.time;
        }

        if (cooldown && Time.time > secondaryWeaponCooldownStamp + secondaryWeaponCooldown)
        {
            cooldown = false;
            firstActivation = true;
            useStamp = Time.time;
        }
    }

    public void SecondaryFireWeapon2()
    {
        GameObject projectileRight = Instantiate(bullet);
        GameObject projectileLeft = Instantiate(bullet);
        projectileRight.transform.position = barrelEndRight.position;
        projectileLeft.transform.position = barrelEndLeft.position;
        projectileRight.transform.rotation = transform.rotation;
        projectileLeft.transform.rotation = transform.rotation;
        Rigidbody rbR = projectileRight.GetComponent<Rigidbody>();
        Rigidbody rbL = projectileLeft.GetComponent<Rigidbody>();
        rbR.AddForce(transform.forward * 70);
        rbL.AddForce(transform.forward * 70);
    }

    public void AddAmmo(int ammo)
    {
        this.ammo += ammo;
    }
}
