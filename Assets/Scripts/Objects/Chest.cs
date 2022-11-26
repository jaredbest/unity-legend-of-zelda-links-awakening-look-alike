using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable {

    [Header ("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue isOpenGlobal;

    [Header ("Signals and Dialog")]
    public SignalGame raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header ("Animations")]
    private Animator anim;

    // Start is called before the first frame update
    void Start () {
        anim = GetComponent<Animator> ();
        isOpen = isOpenGlobal.RuntimeValue;
        if (isOpen) {
            // anim.SetBool ("isOpen", true);
            anim.Play ("isOpen", 0, 1.0f);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown ("Interact") && isPlayerInRange) {
            if (!isOpen) {
                // Open the chest
                OpenChest ();
            } else {
                // Chest is already open
                ChestAlreadyOpen ();
            }
        }
    }

    public void OpenChest () {
        // Dialog window on
        dialogBox.SetActive (true);
        // dialog text = contents text
        dialogText.text = contents.itemDescription;
        // Add contents to player inventory
        playerInventory.AddItem (contents);
        playerInventory.currentItem = contents;
        // Raise the signal to the player to animate
        raiseItem.Raise ();
        // Raise the context clue
        context.Raise ();
        // Set the chest to opened
        isOpen = true;
        anim.SetBool ("isOpen", true);
        isOpenGlobal.RuntimeValue = isOpen;
    }

    public void ChestAlreadyOpen () {
        // Dialog off
        dialogBox.SetActive (false);
        // Raise the signal to the player to stop animating
        raiseItem.Raise ();

    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Player") && !other.isTrigger && !isOpen) {
            context.Raise ();
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Player") && !other.isTrigger && !isOpen) {
            context.Raise ();
            isPlayerInRange = false;
        }
    }
}