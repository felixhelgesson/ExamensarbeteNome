using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour {

    public GameObject match;
    //public ParticleSystem fireParticleSystem;
    private GameObject newMatch;
    public bool matchLit = false;
    public Transform matchLocation;
    private float timer = 1;

    public AudioClip matchLitClip;
    public AudioClip matchOutClip;

    AudioSource aS;

    public Animator anim;
    
	// Use this for initialization
	void Start ()
    {
        aS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        /*Change to button*/
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("LightUp") && timer <= 0)
        {
            if (matchLit)
            {
                Destroy(newMatch, 1);
                matchLit = false;
                timer = 1;
                aS.PlayOneShot(matchOutClip);
                anim.SetTrigger("grabMatch");
                //fireParticleSystem.Stop();
            }
            else if(!matchLit)
            {
                aS.PlayOneShot(matchLitClip);
                anim.SetTrigger("grabMatch");
                matchLit = true;    
                newMatch = Instantiate(match, matchLocation.position, Quaternion.identity) as GameObject;
                newMatch.transform.parent = matchLocation;

                /*The fire should be dealt with in another way. Get top of match for transform instead of new empty object*/
                //fireParticleSystem = Instantiate(fireParticleSystem, firePosition.position, firePosition.rotation);
                //ParticleSystem mPSystem = Instantiate(fireParticleSystem, firePosition.position, firePosition.rotation);
                //fireParticleSystem.transform.parent = this.transform;
                timer = 1;
            }
            
        }      		
	}

    void OnTriggerEnter(Collider other)
    {
        if (matchLit)
        {
            if (other.tag == "Flammable" || other.tag == "Ice" || other.tag == "Freezable")
            {
                Debug.Log("fire");
                other.SendMessageUpwards("SetFire");
            }
        }  
    }
}
