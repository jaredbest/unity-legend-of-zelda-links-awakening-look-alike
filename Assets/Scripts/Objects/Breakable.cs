using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    [Header ("Break Effects")]
    public LootTable thisLoot;

    [Header ("Animations")]
    private Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator> ();
    }

    public void Break () {
        anim.SetBool ("isBroken", true);
        StartCoroutine (BreakCo ());
        DropLoot ();
        if (gameObject.name == "Pot") {
            FindObjectOfType<AudioManager> ().Play ("Pot Breaking");
        }
        if (gameObject.name == "Bush") {
            FindObjectOfType<AudioManager> ().Play ("Bush Breaking");
        }
    }

    private void DropLoot () {
        if (thisLoot != null) {
            PowerUp current = thisLoot.LootPowerUp ();
            if (current != null) {
                Instantiate (current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator BreakCo () {
        yield return new WaitForSeconds (.3f);
        this.gameObject.SetActive (false);
    }
}