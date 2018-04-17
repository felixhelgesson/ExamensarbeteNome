using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWoodCutters : MonoBehaviour
{

    public WoodCutterAnimScript[] woodcutters;
    public ParticleSystem[] particles;
    public Animator garageDoor;
    public Animator deskGenerator;

    void Start()
    {
        for (int j = 0; j < particles.Length; j++)
        {
            particles[j].Stop();
        }
    }
 
    IEnumerator OnTriggerStay(Collider collider)
    {
        if (CheckPowerCell() == true && CheckPower() == true && Input.GetButton("Grab"))
        {

            for (int i = 0; i < woodcutters.Length; i++)
            {
                garageDoor.SetBool("Open_Garage", true);
                deskGenerator.SetBool("StartWCGenerator", true);
                woodcutters[i].startUp = true;
                for (int j = 0; j < particles.Length; j++)
                {
                    particles[j].Play();
                }
                yield return new WaitForSeconds(6);
            }


        }

    }

    bool CheckPowerCell()
    {
        if (GameObject.Find("PowerCellEndPos").GetComponent<PowerCellScript>().powerCell)
        {
            Debug.Log("pCON true");
            return true;

        }
        else
        {
            Debug.Log("pCON false");

            return false;
        }
    }

    bool CheckPower()
    {
        if (GameObject.Find("House/Generator_final/generator_grp/generator_geo/levergeo").GetComponent<GeneratorScript>().powerON)
        {
            Debug.Log("power true");

            return true;

        }
        else
        {
            Debug.Log("power false");

            return false;
        }
    }

}
