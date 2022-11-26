﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Header("Position Variables")]
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    [Header("Position Reset")]
    public VectorValue camMin;
    public VectorValue camMax;

    [Header("Animations")]
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        minPosition = camMin.initialValue;
        maxPosition = camMax.initialValue;
        anim = GetComponent<Animator>();
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                target.position.y,
                transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                minPosition.x,
                maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                minPosition.y,
                maxPosition.y);

            transform.position = Vector3.Lerp(transform.position,
                targetPosition, smoothing);
            //transform.position = Vector3.Lerp(transform.position,
            //                                 targetPosition, smoothing);
        }
    }

    private Vector3 RoundPosition(Vector3 position)
    {
        float xOffset = position.x % .0625f;
        if (xOffset != 0)
        {
            position.x -= xOffset;
        }
        float yOffset = position.y % .0625f;
        if (yOffset != 0)
        {
            position.y -= yOffset;
        }
        return position;
    }

    public void BeginScreenKick()
    {
        anim.SetBool("isScreenKickActive", true);
        StartCoroutine(ScreenKickCo());
    }

    public IEnumerator ScreenKickCo()
    {
        yield return null;
        anim.SetBool("isScreenKickActive", false);
    }
}