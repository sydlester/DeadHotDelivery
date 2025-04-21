using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManagePlayerWeapon : MonoBehaviour
{
    public Weapon playerWeapon;
    public WeaponManager weaponManager;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the player's weapon to the knife 
        GameObject weaponManagerObject = GameObject.Find("WeaponManager");
        weaponManager = weaponManagerObject.GetComponent<WeaponManager>();
        Weapon knife = weaponManager.GetWeapon("Knife");

        playerWeapon = new Weapon();
        playerWeapon.name = knife.name;
        playerWeapon.damage = knife.damage;
        playerWeapon.range = knife.range;
        playerWeapon.cd = knife.cd;
        Debug.Log("Player's weapon: " + playerWeapon.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPlayerWeapon(string weaponName)
    {
        playerWeapon = weaponManager.GetWeapon(weaponName);
        Debug.Log("Switched to weapon: " + playerWeapon.name);
    }
}
