using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    public GameObject contextClue;
    public bool isContextActive;

    public void ChangeContext()
    {
        isContextActive = !isContextActive;
        if (isContextActive)
        {
            contextClue.SetActive(true);
        }
        else
        {
            contextClue.SetActive(false);
        }

    }

}