using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Weapon
{
    public string name;
    public int damage;
    public float range;
    public float cd;
}

public class ManageWeapons : MonoBehaviour
{

    public Weapon knife = new Weapon {
        name = "Knife",
        damage = 25,
        range = 5f,
        cd = 0.25f,
    };
    
    public Weapon sword = new Weapon {
        name = "Sword",
        damage = 50,
        range = 7f,
        cd = 0.25f,
    };

    public Weapon playerWeapon;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the player's weapon to the knife 
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
}
