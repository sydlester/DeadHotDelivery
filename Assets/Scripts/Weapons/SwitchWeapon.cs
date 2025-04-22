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
    public GameObject pickupPopup;
    public bool canPickup = false;

    // Start is called before the first frame update
    void Start()
    {
        updateLocation = GetComponent<UpdateLocation>();
        player = GameObject.FindGameObjectWithTag("Player");
        manageWeapons = player.GetComponent<ManagePlayerWeapon>();
        // Debug.Log("SwitchWeapon: Start");
        pickupPopup = GameObject.Find("PickupPopup");
        pickupPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputAllowed)
        {
            return;
        }
        if (!canPickup)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.E))
                {
                    SwitchWeaponTo(otherWeapon);
                    canPickup = false;
                    // update the player's weapon
                    if (otherWeapon.GetComponent<UpdateLocation>().weaponName == "Sword")
                    {
                        manageWeapons.SwitchPlayerWeapon("Sword");
                    }
                    else if (otherWeapon.GetComponent<UpdateLocation>().weaponName == "Knife")
                    {
                        manageWeapons.SwitchPlayerWeapon("Knife");
                    }     
                    if (pickupPopup != null)
                    {
                        pickupPopup.SetActive(false);
                    }
                }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        otherWeapon = other;
        //Debug.Log("SwitchWeapon: OnTriggerEnter2D");
        if (other.CompareTag("Weapon"))
        {
            if (pickupPopup != null)
                {
                    Debug.Log("Pickup Popup");
                    pickupPopup.SetActive(true);
                }
            Debug.Log("Overlap Weapon");
            // only trigger for one of the two weapons
            if (updateLocation.inUse)
            {
                // highlight the weapon
                canPickup = true;
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
            canPickup = false;
            if (pickupPopup != null)
            {
                pickupPopup.SetActive(false);
            }
        }
    }

    void SwitchWeaponTo(Collider2D other)
    {
        Vector2 inUsePos = transform.position;
        Vector2 otherPos = other.transform.position;

        // current in use weapon gets put down
        updateLocation.inUse = !(updateLocation.inUse);
        transform.position = otherPos;
        SwitchColors(GetComponent<SpriteRenderer>(), updateLocation.inUse);

        // pick up new weapon
        other.GetComponent<UpdateLocation>().inUse = !(other.GetComponent<UpdateLocation>().inUse);
        other.transform.position = inUsePos;
        SwitchColors(other.GetComponent<SpriteRenderer>(), other.GetComponent<UpdateLocation>().inUse);

    }

    void SwitchColors(SpriteRenderer spriteRenderer, bool inUse)
    {
        if (!inUse)
        {
            spriteRenderer.color = Color.yellow;
        }
        else if (inUse)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
