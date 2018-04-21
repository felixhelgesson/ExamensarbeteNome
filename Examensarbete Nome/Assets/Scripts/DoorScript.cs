using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public bool finalDoor = false;
    public PickUpHandler ph;
    public GeneratorScript checkPower;
    public AudioClip doorOpenClose;
    public AudioClip deniedAccess;

    Animator animator;
    AudioSource aS;
    bool doorOpen;
    Light doorLight;
    bool turnedON = false;
    bool key1 = false;
    bool key2 = false;

    int doorState = 3;

    void Start()
    {
        doorOpen = false;
        animator = GetComponent<Animator>();
        doorLight = GetComponentInChildren<Light>();
        aS = GetComponent<AudioSource>();

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
        switch (doorState)
        {
            case 3:

                doorOpen = false;
                doorLight.color = Color.yellow;
                // DoorControll("Close");
                animator.SetBool("OpenDoor", false);
                animator.SetBool("ClosedDoor", true);

                break;

            case 2:

                doorOpen = false;
                doorLight.color = Color.red;
                // DoorControll("Close");
                animator.SetBool("OpenDoor", false);
                animator.SetBool("ClosedDoor", true);
                break;

            case 1:

                doorOpen = true;
                doorLight.color = Color.green;
                //DoorControll("Open");
                animator.SetBool("OpenDoor", true);
                animator.SetBool("ClosedDoor", false);
                break;
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (checkPower.powerON == true && col.gameObject.tag == "Grabable"|| checkPower.powerON == true && col.gameObject.tag == "Vaccum")
        {

            doorState = 1;
            aS.PlayOneShot(doorOpenClose);
            //DoorControll("Open");
        }

        else if (finalDoor == true)
        {
            FinalDoor();
        }


    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Vaccum" || col.gameObject.tag == "Grabable" && checkPower.powerON == true )
        {
            aS.PlayOneShot(doorOpenClose);

            doorState = 3;
            doorOpen = false;
        }

        else if (col.gameObject.tag == "Player")
        {

            doorState = 3;
            doorOpen = false;

        }


    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Vaccum" && checkPower.powerON == true || col.gameObject.tag == "Grabable" && checkPower.powerON == true)
        {
            doorState = 1;
            doorOpen = true;

        }
        else if (finalDoor == true)
        {
            FinalDoor();
        }
        else if (col.gameObject.tag == "Player" && doorOpen == false)
        {
            if(!aS.isPlaying)
            {
            aS.PlayOneShot(deniedAccess);

            }

            doorState = 2;
            doorOpen = false;
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
            doorOpen = true;
            if (!aS.isPlaying)
                aS.PlayOneShot(doorOpenClose);


        }
    }




}