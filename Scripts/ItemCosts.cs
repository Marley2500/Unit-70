using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCosts : MonoBehaviour
{
    public int cost;
    public TMP_Text buttonName;

    private void Start()
    {
        buttonName = GetComponentInChildren<TMP_Text>();
        buttonName.text = gameObject.name + ": " + cost + " Gold";
    }

    public void ButtonUpdate() 
    {
        buttonName.text = gameObject.name + ": " + cost + " Gold";
    }
}
