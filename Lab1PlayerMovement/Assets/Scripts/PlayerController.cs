using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Canvas cockpitCamera;
    public Image HPBar;

    float vInput;
    float hInput;
    float fire;
    float secondaryFire;
    float moveBoost;

    float hp = 100.0f;

    float movementSpeed = 30.0f;
    float rotationSpeed = 30.0f;
    float movementBoost = 1.0f;

    //boolean variables
    bool movementBoostCooldown = false;
    bool onCooldown = false;
    bool activated = false;
    bool weapon2PickedUp = false;
    enum weaponSelected
    {
        weapon1,
        weapon2
    }
    weaponSelected selectedWeapon = weaponSelected.weapon1;

    public enum cameraMode
    {
        thirdPerson,
        firstPerson,
        topDown
    }

    bool delay = true;
    bool active = false;

    public cameraMode thirdPerson = cameraMode.firstPerson;

    float delayStampWeapon1;
    float delayStampWeapon2;

    float movementBoostUseStamp;
    float movementBoostUseTime = 2.0f;
    float movementBoostCooldownStamp;
    float movementBoostCooldownTime = 10.0f;

    GameObject weapon;

    // Use this for initialization
    void Start()
    {
        weapon = transform.GetChild(0).gameObject;
        cockpitCamera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        fire = Input.GetAxis("Fire1");
        secondaryFire = Input.GetAxis("Fire2");
        moveBoost = Input.GetAxis("Fire3");

        transform.Translate(Vector3.forward * vInput * movementSpeed * Time.deltaTime * movementBoost);

        transform.Rotate(Vector3.up, hInput * rotationSpeed * Time.deltaTime);

        if (thirdPerson == cameraMode.firstPerson)
        {
            cockpitCamera.gameObject.SetActive(true);
        }
        else
        {
            cockpitCamera.gameObject.SetActive(false);
        }

        if (delay && Input.GetAxis("ToggleThirdPerson") > 0)
        {
            if (thirdPerson == cameraMode.firstPerson)
            {
                thirdPerson = cameraMode.thirdPerson;
            }
            else if (thirdPerson == cameraMode.thirdPerson)
            {
                thirdPerson = cameraMode.topDown;
            }
            else
            {
                thirdPerson = cameraMode.firstPerson;
            }
            delay = false;
        }
        if (Input.GetAxis("ToggleThirdPerson") == 0)
        {
            delay = true;
        }

        if (fire > 0 && Time.time > delayStampWeapon1 + 1)
        {
            weapon.GetComponent<FireGrenade>().PrimaryFire();
            delayStampWeapon1 = Time.time;
        }

        if (secondaryFire > 0 && Time.time > delayStampWeapon2 + 0.15 && selectedWeapon == weaponSelected.weapon1)
        {
            weapon.GetComponent<FireGrenade>().SecondaryFire();
            delayStampWeapon2 = Time.time;
        }
        else if (secondaryFire > 0 && selectedWeapon == weaponSelected.weapon2)
        {
            weapon.GetComponent<FireGrenade>().SecondaryFireWeapon2();
        }

        weapon.transform.Rotate(Input.GetAxis("Mouse Y") * -10, 0, 0);

        if (weapon.transform.rotation.eulerAngles.x < 315.0f && weapon.transform.rotation.eulerAngles.x > 290.0f)
        {
            weapon.transform.rotation = Quaternion.Euler(315.0f, weapon.transform.rotation.eulerAngles.y, weapon.transform.rotation.eulerAngles.z);
        }
        else if (weapon.transform.rotation.eulerAngles.x > 30.0f && weapon.transform.rotation.eulerAngles.x < 315.0f)
        {
            weapon.transform.rotation = Quaternion.Euler(30.0f, weapon.transform.rotation.eulerAngles.y, weapon.transform.rotation.eulerAngles.z);
        }

        if (moveBoost > 0 && !movementBoostCooldown)
        {
            if (Time.time < movementBoostUseStamp + movementBoostUseTime || !activated)
            {
                movementBoost = 3.0f;
                if (!activated)
                {
                    activated = true;
                    movementBoostUseStamp = Time.time;
                }
            }
        }
        else if (Time.time > movementBoostUseStamp + movementBoostUseTime && activated && !movementBoostCooldown)
        {
            movementBoostCooldown = true;
            movementBoost = 1.0f;
        }
        if (movementBoostCooldown && !onCooldown)
        {
            onCooldown = true;
            movementBoostCooldownStamp = Time.time;
        }
        if (movementBoostCooldown && Time.time > movementBoostCooldownStamp + movementBoostCooldownTime)
        {
            movementBoostCooldown = false;
            activated = false;
            onCooldown = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = weaponSelected.weapon1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && weapon2PickedUp)
        {
            selectedWeapon = weaponSelected.weapon2;
        }
        if (hp <= 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "AmmoPack")
        {
            weapon.GetComponent<FireGrenade>().AddAmmo(collision.gameObject.GetComponent<AmmoBox>().ammoBoost);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "SecondaryWeapon")
        {
            weapon2PickedUp = true;
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Radar")
        {
            other.gameObject.GetComponent<TurretRadar>().player = gameObject;
        }
    }

    public void LoseHP()
    {
        hp -= 10;
        HPBar.rectTransform.sizeDelta = new Vector2(30 * (hp/10), HPBar.rectTransform.sizeDelta.y);
    }

}
