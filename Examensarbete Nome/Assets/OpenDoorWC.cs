using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorWC : MonoBehaviour {

    public DoorScript door; 

    void OnTriggerEnter(Collider col)
    {
        door.DoorControll("Open");
    }

}
