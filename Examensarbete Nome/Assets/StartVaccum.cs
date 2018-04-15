using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVaccum : MonoBehaviour
{

    public RobotBehaviour vaccumAIScript;



    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Player" && this.tag == "wallSwitch")
    //    {

    //        vaccumAIScript.activated = true;
    //        vaccumAIScript.animator.SetBool("isActive", true);
    //    }
    //}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "VaccumTarget" || col.gameObject.tag == "CleaningRobot")
        {
            vaccumAIScript.animator.SetBool("isActive", true);

            vaccumAIScript.triggerTrans = col.gameObject.transform;
            vaccumAIScript.triggerd = true;
            vaccumAIScript.activated = true;
        }


    }

}
