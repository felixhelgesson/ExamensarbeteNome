using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCellScript : MonoBehaviour {

    public bool powerCell = false;
    Light doorLight;

    void Start()
    {
        doorLight = GetComponent<Light>();
        doorLight.intensity = 0;
        doorLight.color = Color.cyan;
    }


    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Grabable")
        {
            powerCell = true;
            coll.gameObject.transform.position = this.transform.position;
            doorLight.intensity = 2;
        }
    }
}
