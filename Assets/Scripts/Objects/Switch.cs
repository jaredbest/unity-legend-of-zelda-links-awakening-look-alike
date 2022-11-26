using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public bool isActive;
    public BoolValue isActiveGlobal;
    public Sprite activeSprite;
    private SpriteRenderer mySprite;
    public LockedDoor thisDoor;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        isActive = isActiveGlobal.RuntimeValue;
        if (isActive)
        {
            ActivateSwitch();
        }
    }

    public void ActivateSwitch()
    {
        isActive = true;
        isActiveGlobal.RuntimeValue = isActive;
        thisDoor.Open();
        mySprite.sprite = activeSprite;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Is it the player?
        if (other.CompareTag("Player"))
        {
            ActivateSwitch();
        }
    }
}