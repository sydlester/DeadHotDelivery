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

public class WeaponManager : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Weapon GetWeapon(string weaponName)
    {
        switch (weaponName)
        {
            case "Knife":
                return knife;
            case "Sword":
                return sword;
            default:
                return knife; // Default to knife if no match found
        }
    }
}

