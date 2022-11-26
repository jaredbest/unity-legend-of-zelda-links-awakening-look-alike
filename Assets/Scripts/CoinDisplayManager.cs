using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplayManager : MonoBehaviour
{

    public Inventory playerInventory;
    public TextMeshProUGUI coinDisplay;

    public void UpdateCoinCount()
    {
        coinDisplay.text = "" + playerInventory.coins;
    }
}