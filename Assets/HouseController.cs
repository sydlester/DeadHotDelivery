using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField] DeliveryData deliveryData;
    [SerializeField] QuestController questController;
    public void Awake() {
        questController = FindObjectOfType<QuestController>();
        StartCoroutine(SetupSequence());
    }

    private IEnumerator SetupSequence()
    {
        yield return StartCoroutine(deliveryData.InitializeHouses());
        questController.DeliveryQuest();
    }

}
