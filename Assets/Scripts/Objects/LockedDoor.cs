using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    buttonSwitch
}

public class LockedDoor : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (isPlayerInRange && thisDoorType == DoorType.key)
            {
                //Does the player have a key?
                if (playerInventory.numberOfKeys > 0)
                {
                    //Remove a player key
                    playerInventory.numberOfKeys--;
                    //If so, then call the open method
                    Open();
                }
            }
        }
    }

    public void Open()
    {
        //Turn off the door's sprite renderer
        doorSprite.enabled = false;
        //set open to true
        open = true;
        //turn off the door's box collider
        physicsCollider.enabled = false;
    }

    public void Close()
    {
        //Turn on the door's sprite renderer
        doorSprite.enabled = true;
        //set open to false
        open = false;
        //turn on the door's box collider
        physicsCollider.enabled = true;
    }
}