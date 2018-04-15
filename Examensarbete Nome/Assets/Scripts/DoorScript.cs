using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    Animator animator;
    bool doorOpen;
    Light doorLight;
    public GeneratorScript checkPower;
    bool turnedON = false;

    public bool finalDoor = false;
    public PickUpHandler ph;
    bool key1 = false;
    bool key2 = false;

    int doorState = 3;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
        doorLight = GetComponentInChildren<Light>();

        doorLight.color = Color.yellow;
        doorLight.intensity = 0;
        
    }

    void Update()
    {
        if (checkPower.powerON == true && turnedON == false)
        {
            doorLight.intensity = 3;
            turnedON = true;
        }

        DoorCtrl();
    }

    void DoorCtrl()
    {
        switch(doorState)
        {
            case 3:
                doorLight.color = Color.yellow;
                doorOpen = false;
               // DoorControll("Close");
                animator.SetBool("OpenDoor", false);
                animator.SetBool("ClosedDoor", true);

                break;

            case 2:
                doorLight.color = Color.red;
                doorOpen = false;
               // DoorControll("Close");
                animator.SetBool("OpenDoor", false);
                animator.SetBool("ClosedDoor", true);
                break;

            case 1:
                doorLight.color = Color.green;
                doorOpen = true;
                //DoorControll("Open");
                animator.SetBool("OpenDoor", true);
                animator.SetBool("ClosedDoor", false);
                break;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (checkPower.powerON == true && col.gameObject.tag == "Grabable" || checkPower.powerON == true && col.gameObject.tag == "Vaccum")
        {

            doorState = 1;            
            //doorOpen = true;
            //DoorControll("Open");
        }

        else if (finalDoor == true)
        {
            FinalDoor();
        }
    

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Vaccum"|| col.gameObject.tag == "Grabable")
        {
           
        doorState = 3;
        }

        else if (col.gameObject.tag == "Player")
        {
            doorState = 3;
        }


    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Vaccum" || col.gameObject.tag == "Grabable")
        {
            doorState = 1;
     
        }
        else if (finalDoor == true)
        {
            FinalDoor();
        }
        else if (col.gameObject.tag == "Player")
        {
            doorState = 2;
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

        if (key1 == true && key2 == true)
        {
            doorState = 1;
                       
        }
    }

}
