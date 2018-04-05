using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {

    public bool powerON = false;
    Animator generatorAnimCtrl;


	// Use this for initialization
	void Start () {

        generatorAnimCtrl = GetComponentInParent<Animator>();
		
	}

    void OnTriggerEnter(Collider col)
    {
        generatorAnimCtrl.SetBool("StartGenerator", true);
        powerON = true;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
