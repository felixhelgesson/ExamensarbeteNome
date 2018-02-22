﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRailMover : MonoBehaviour
{
    public CameraRail rail;
    public Transform lookAt;
    public Transform player;

    public bool smoothMove = true;
    public float moveSpeed = 5.0f;


    Vector3 lastPosition;
    Transform thisTransform;

	void Start ()
    {
        thisTransform = transform;
        lastPosition = thisTransform.position;
	}
	
	void Update ()
    {
        if (smoothMove)
        {
            lastPosition = Vector3.Lerp(lastPosition, rail.ProjectPositionOnRail(player.position), Time.deltaTime * moveSpeed);
            thisTransform.position = lastPosition;
        }
        else
        {
            thisTransform.position = rail.ProjectPositionOnRail(player.position);
        }

        thisTransform.LookAt(lookAt.position);
	}
}
