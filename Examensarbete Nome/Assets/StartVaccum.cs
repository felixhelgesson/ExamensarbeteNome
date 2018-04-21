using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVaccum : MonoBehaviour
{

    public RobotBehaviour vaccumAIScript;
    public AudioSource audioS;



    

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "VaccumTarget" && !vaccumAIScript.activated && !vaccumAIScript.dead)
        {
            vaccumAIScript.animator.SetBool("isActive", true);
            audioS.Play();

            vaccumAIScript.triggerTrans = col.gameObject.transform;
            vaccumAIScript.triggerd = true;
            vaccumAIScript.activated = true;
        }
        else if(col.gameObject.tag == "CleaningRobot" && !vaccumAIScript.dead)
        {

            vaccumAIScript.triggerTrans = col.gameObject.transform;
            vaccumAIScript.triggerd = true;
            vaccumAIScript.activated = true;
        }
        else if (col.gameObject.tag == "VaccumTarget" && vaccumAIScript.activated && !vaccumAIScript.dead)
        {

            vaccumAIScript.triggerTrans = col.gameObject.transform;
            vaccumAIScript.triggerd = true;
            vaccumAIScript.activated = true;
        }


    }

}
