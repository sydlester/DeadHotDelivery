using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private UpdateLocation updateLocation;
    private ManagePlayerWeapon manageWeapons;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        updateLocation = GetComponent<UpdateLocation>();
        player = GameObject.FindGameObjectWithTag("Player");
        manageWeapons = player.GetComponent<ManagePlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Weapon"))
        {
            // only trigger for one of the two weapons
            if (updateLocation.inUse)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SwitchWeaponTo(other);
                    // update the player's weapon
                    if (other.GetComponent<UpdateLocation>().weaponName == "Sword")
                    {
                        manageWeapons.SwitchPlayerWeapon("Sword");
                    }
                    else if (other.GetComponent<UpdateLocation>().weaponName == "Knife")
                    {
                        manageWeapons.SwitchPlayerWeapon("Knife");
                    }     
                }
            }
        }
    }

    void SwitchWeaponTo(Collider2D other)
    {
        Vector2 inUsePos = transform.position;
        Vector2 otherPos = other.transform.position;

        // current in use weapon gets put down
        updateLocation.inUse = false;
        transform.position = otherPos;

        // pick up new weapon
        other.GetComponent<UpdateLocation>().inUse = true;
        other.transform.position = inUsePos;
    }
}
