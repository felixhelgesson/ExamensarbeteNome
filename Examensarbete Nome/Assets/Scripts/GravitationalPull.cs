using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalPull : MonoBehaviour
{

    public GameObject[] target;

    GameObject deadTarget;

    //public Rigidbody rbTarget;
    public float pullForce;
    public bool pullOn = true;
    private bool resetPull;
    private float timer;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("VaccumTarget");
        //
        deadTarget = GameObject.FindGameObjectWithTag("CleaningRobot");
        //rbTarget = target.gameObject.GetComponent<Rigidbody>();

        //Fixs the problem with Vaccumholdscript regardning the rbtarget
    }

    // Update is called once per frame
    void Update()
    {
        if (resetPull)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                pullOn = true;
                resetPull = false;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < target.Length; i++)
        {
            if (other.gameObject == target[i] && pullOn)
            {
                target[i].transform.position = Vector3.MoveTowards(target[i].transform.position, transform.position, pullForce * Time.deltaTime);
                
            }

        }

        if(other.gameObject == deadTarget && pullOn)
        {
            deadTarget.transform.position = Vector3.MoveTowards(deadTarget.transform.position, transform.position, pullForce  * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        resetPull = true;
        timer = 3;
    }
}
