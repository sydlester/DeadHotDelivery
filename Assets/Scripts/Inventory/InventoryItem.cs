using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    public ItemSO itemScriptableObject;
    [SerializeField] Image iconImage;

    void Start()
    {
        if (itemScriptableObject != null)
            iconImage.sprite = itemScriptableObject.icon;
    }

}
