using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    public SignalGame context;
    public bool isPlayerInRange;

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag ("Player") && !other.isTrigger) {
            context.Raise ();
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag ("Player") && !other.isTrigger) {
            context.Raise ();
            isPlayerInRange = false;
        }
    }

}