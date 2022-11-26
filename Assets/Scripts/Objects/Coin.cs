using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{

    public Inventory playerInventory;

    void Start()
    {
        powerUpSignal.Raise();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.coins += 1;
            powerUpSignal.Raise();
            FindObjectOfType<AudioManager>().Play("Collect Coin");
            Destroy(this.gameObject);
        }
    }
}