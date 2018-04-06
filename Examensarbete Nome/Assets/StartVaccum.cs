using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartVaccum : MonoBehaviour {

    bool startVaccum = false;
    public RobotBehaviour vaccumAIScript;

    //void Start()
    //{
    //    GameObject g = GameObject.FindGameObjectWithTag("Vaccum");
    //    vaccumAIScript = g.GetComponent<RobotBehaviour>();
    //}

	void OnTriggerEnter(Collider col)
    {
        //Play animations here aswell.
        vaccumAIScript.activated = true;
    }

    
}
