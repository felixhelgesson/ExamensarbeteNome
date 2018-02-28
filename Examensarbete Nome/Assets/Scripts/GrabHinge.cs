using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabHinge : MonoBehaviour {
   public bool hasJoint;
    public GameObject tomtehand;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint)
        {
            gameObject.AddComponent<HingeJoint>();
            gameObject.GetComponent<HingeJoint>().connectedBody = collision.rigidbody;
            gameObject.GetComponent<HingeJoint>().connectedAnchor = tomtehand.transform.position;
            hasJoint = true;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
