﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {
    public float movementSpeed;
    public bool functional;

    VacuumHoldLaunch vScript;
    // Use this for initialization
    void Start () {
        functional = true;
        Path();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void Path()
    {
       iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("VaccumPath"), "speed",movementSpeed, "orientToPath", true, "delay", 0,"oncomplete","Check", "easetype", iTween.EaseType.easeInOutQuad));

    }

    void Check()
    {
        if (functional)
        {
            Path();
            //GameObject vaccum = GameObject.Find("Stuck&LaunchPoint");
            //vScript = vaccum.GetComponent<VacuumHoldLaunch>();
            //vScript.Launch();
        }
    }

}
