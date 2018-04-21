using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    public string name = "Name here";
    AudioSource aS;

	// Use this for initialization
	void Start ()
    {
        aS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {		
	}

    public string Collect()
    {
        aS.Play();
        Destroy(gameObject, 0.5f);
        return name;
    }
}
