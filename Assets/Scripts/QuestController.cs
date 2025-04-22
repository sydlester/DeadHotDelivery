using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestController : MonoBehaviour
{
    public TMP_Text questText;
    
    // Sets top left UI text
    public void SetQuest(string quest)
    {
        questText.text = quest;
    }
}
