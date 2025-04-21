using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private UpdateLocation updateLocation;
    private ManagePlayerWeapon manageWeapons;
    private GameObject player;
    private bool inputAllowed = false;
    public Collider2D otherWeapon;

    // Start is called before the first frame update
    void Start()
    {
        updateLocation = GetComponent<UpdateLocation>();
        player = GameObject.FindGameObjectWithTag("Player");
        manageWeapons = player.GetComponent<ManagePlayerWeapon>();
        // Debug.Log("SwitchWeapon: Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputAllowed)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
                {
                    SwitchWeaponTo(otherWeapon);
                    // update the player's weapon
                    if (otherWeapon.GetComponent<UpdateLocation>().weaponName == "Sword")
                    {
                        manageWeapons.SwitchPlayerWeapon("Sword");
                    }
                    else if (otherWeapon.GetComponent<UpdateLocation>().weaponName == "Knife")
                    {
                        manageWeapons.SwitchPlayerWeapon("Knife");
                    }     
                }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        otherWeapon = other;
        //Debug.Log("SwitchWeapon: OnTriggerEnter2D");
        if (other.CompareTag("Weapon"))
        {
            Debug.Log("Overlap Weapon");
            // only trigger for one of the two weapons
            if (updateLocation.inUse)
            {
                // highlight the weapon
                other.GetComponent<SpriteRenderer>().color = Color.yellow;
                inputAllowed = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            if (updateLocation.inUse)
            {
                // reset color
                other.GetComponent<SpriteRenderer>().color = Color.white;
                inputAllowed = false;
            }
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    void SwitchWeaponTo(Collider2D other)
    {
        Vector2 inUsePos = transform.position;
        Vector2 otherPos = other.transform.position;

        // current in use weapon gets put down
        updateLocation.inUse = false;
        transform.position = otherPos;
        GetComponent<SpriteRenderer>().color = Color.yellow;

        // pick up new weapon
        other.GetComponent<UpdateLocation>().inUse = true;
        other.transform.position = inUsePos;
        other.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
