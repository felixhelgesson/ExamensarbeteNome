using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccumSuck : MonoBehaviour {

    public RobotBehaviour vaccumAIScript;

  

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "VaccumTarget")
        {
            vaccumAIScript.triggerd = false;
            vaccumAIScript.agent.destination = vaccumAIScript.patrolPoints[0].position;
            Destroy(col.gameObject);
        }
        else if(col.gameObject.tag == "CleaningRobot")
        {
            vaccumAIScript.dead = true;
            vaccumAIScript.activated = false;
            
            Destroy(col.gameObject.transform.parent.gameObject);
        }
    }
}
