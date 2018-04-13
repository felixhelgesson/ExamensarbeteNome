using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    Animator animator;
    bool doorOpen;
    Light[] doorLights;
    public GeneratorScript checkPower;
    bool turnedON = false;

    public bool finalDoor = false;
    public PickUpHandler ph;
    bool key1 = false;
    bool key2 = false;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
        doorLights = GetComponentsInChildren<Light>();
        foreach (Light l in doorLights)
        {
            l.color = Color.yellow;
            l.intensity = 0;
        }
    }

    void Update()
    {
        if(checkPower.powerON == true && turnedON == false)
        {
            foreach (Light l in doorLights)
            {
                l.intensity = 2;
            }

            turnedON = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag + "Entered");

        if (checkPower.powerON == true && col.gameObject.tag == "Grabable" || checkPower.powerON == true && col.gameObject.tag == "Vaccum")
        {
            foreach (Light l in doorLights)
            {
                l.color = Color.green;
            }
            doorOpen = true;
            DoorControll("Open");
        }

        else if(finalDoor == true)
        {
            FinalDoor();
        }
        else if (col.gameObject.tag == "Player")
        {
            foreach (Light l in doorLights)
            {
                l.color = Color.red;
            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        //Debug.Log(col.gameObject.tag + "Stay");

        if (checkPower.powerON == true && col.gameObject.tag == "Grabable" || checkPower.powerON == true && col.gameObject.tag == "Vaccum")
        {
            foreach (Light l in doorLights)
            {
                l.color = Color.green;
            }
            doorOpen = true;
            DoorControll("Open");
        }
    }

    void OnTriggerExit(Collider col)
    {
        //Debug.Log(col.gameObject.tag + "Exit");
        if(doorOpen)
        {
            doorOpen = false;
            DoorControll("Close");
            foreach (Light l in doorLights)
            {
                l.color = Color.yellow;
            }
        }
    }

    public void DoorControll(string direction)
    {
        animator.SetTrigger(direction);
    }

    void FinalDoor()
    {
        key1 = ph.wcKey;
        key2 = ph.vaccumKey;

        if(key1 == true && key2 == true)
        {
            foreach (Light l in doorLights)
            {
                l.color = Color.green;
            }
            doorOpen = true;
            Debug.Log("OpenDoor");
            DoorControll("Open");
        }
    }

}
