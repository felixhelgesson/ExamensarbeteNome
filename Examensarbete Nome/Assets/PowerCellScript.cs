using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerCellScript : MonoBehaviour
{

    public bool powerCell = false;
 
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Grabable")
        {
            powerCell = true;
            coll.gameObject.transform.position = Vector3.Lerp(coll.gameObject.transform.position, this.transform.position, 1f);
        }
    }

   
}
