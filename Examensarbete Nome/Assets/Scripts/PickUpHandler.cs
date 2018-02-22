﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpHandler : MonoBehaviour {

    //Should probably not be public
    public bool kitchenKey = false;
    public bool vacuumKey = false;
    public bool tableKey = false;
    public bool tvKey = false;
    public GameObject inventory;

	// Use this for initialization
	void Start ()
    {		
	}
	
	// Update is called once per frame
	void Update ()
    {		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            PickUp pickUp = other.GetComponent<PickUp>();
            string collectedItem = pickUp.Collect();
            UpdateCollections(collectedItem);
        }
    }

    /*If this gets to big, we should consider a database*/
    void UpdateCollections(string collectedItem)
    {
        switch (collectedItem)
        {
            case "TableRobotKey":
                tableKey = true;
                inventory.transform.Find("TableRobotKey").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/inventory_key_active");
                break;

            case "VacuumKey":
                vacuumKey = true;
                inventory.transform.Find("VacuumKey").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/inventory_key_active");
                break;

            case "TVKey":
                tvKey = true;
                inventory.transform.Find("TVKey").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/inventory_key_active");
                break;

            case "KitchenKey":
                kitchenKey = true;
                inventory.transform.Find("KitchenKey").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Images/inventory_key_active");
                break;

            default:
                break;
        }
    }
}
