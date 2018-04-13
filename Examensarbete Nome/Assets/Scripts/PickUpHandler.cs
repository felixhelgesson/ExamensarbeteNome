using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpHandler : MonoBehaviour {

    //Should probably not be public
    public bool wcKey = false;
    public bool vaccumKey = false;
 


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUpWC")
        {
            PickUp pickUp = other.GetComponent<PickUp>();
            pickUp.Collect();
            wcKey = true;
        }
        else if(other.tag == "PickUpVaccum")
        {
            PickUp pickUp = other.GetComponent<PickUp>();
            pickUp.Collect();
            vaccumKey = true;
        }
    }

   
}
