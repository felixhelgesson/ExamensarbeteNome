using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    Animator animator;
    public string startState;
    bool doorOpen;


    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
        DoorControll(startState);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" || col.gameObject.tag == "Vaccum")
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
