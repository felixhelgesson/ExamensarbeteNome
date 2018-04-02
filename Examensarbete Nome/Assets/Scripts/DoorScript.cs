﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    Animator animator;
    bool doorOpen;


    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            doorOpen = true;
            DoorControll("Open");
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(doorOpen)
        {
            doorOpen = false;
            DoorControll("Close");
        }
    }

    void DoorControll(string direction)
    {
        animator.SetTrigger(direction);
    }
}
