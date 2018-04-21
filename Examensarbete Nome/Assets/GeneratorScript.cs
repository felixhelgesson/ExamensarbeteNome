using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorScript : MonoBehaviour {

    public bool powerON = false;
    public AudioClip generatorStartSound;
    public AudioClip generatorRunSound;

    AudioSource aS;
    Animator generatorAnimCtrl;
    


	// Use this for initialization
	void Start () {

        generatorAnimCtrl = GetComponentInParent<Animator>();
        aS = GetComponent<AudioSource>();
		
	}

    void OnTriggerEnter(Collider col)
    {
        generatorAnimCtrl.SetBool("StartGenerator", true);
        aS.PlayOneShot(generatorStartSound);
        powerON = true;
    }

	
	// Update is called once per frame
	void Update () {

        if(!aS.isPlaying && powerON)
        {
            aS.PlayOneShot(generatorRunSound);
        }
		
	}
}
