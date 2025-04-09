using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{

    public string name;
    public int num;
    public Sprite icon;
    public GameObject prefab;
    public int maxStack;
}
