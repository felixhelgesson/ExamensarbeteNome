using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWoodCutters : MonoBehaviour {

    public WoodCutterAnimScript[] woodcutters;
    public Animator garageDoor;

   

    IEnumerator OnTriggerEnter(Collider collider)
    {
        for (int i = 0; i < woodcutters.Length; i++)
        {
            garageDoor.SetBool("Open_Garage", true);
            woodcutters[i].startUp = true;
            yield return new WaitForSeconds(6);

        }


    }

   

}
