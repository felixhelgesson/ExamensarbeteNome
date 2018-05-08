using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWoodCutters : MonoBehaviour
{

    public WoodCutterAnimScript[] woodcutters;
    public ParticleSystem[] particles;
    public Animator garageDoor;
    public Animator deskGenerator;

    public AudioClip computerOn;
    public AudioSource wcGenAS;
    public AudioClip wcGeneratorRunning;
    public AudioSource garageGateAS;
    public AudioClip garagetGateOpen;
    public Material material1, material2;

    public GeneratorScript gScript;
    AudioSource aS;
    bool wcOn = false;

    void Start()
    {
        for (int j = 0; j < particles.Length; j++)
        {
            particles[j].Stop();
        }
        aS = GetComponent<AudioSource>();
    }

    void LateUpdate()
    {
        CheckPowerCell();
        if(!wcGenAS.isPlaying && wcOn)
        {
            wcGenAS.PlayOneShot(wcGeneratorRunning);
        }
    }
 
    IEnumerator OnTriggerStay(Collider collider)
    {
        if (CheckPowerCell() == true && CheckPower() == true && Input.GetButton("Grab") && !wcOn)
        {
            aS.PlayOneShot(computerOn);
            for (int i = 0; i < woodcutters.Length; i++)
            {
                wcOn = true;
                garageDoor.SetBool("Open_Garage", true);
                wcGenAS.PlayOneShot(wcGeneratorRunning);
                garageGateAS.PlayOneShot(garagetGateOpen);
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

            GetComponent<Renderer>().material = material2;
            return true;

        }
        else
        {

            return false;
        }
    }

    bool CheckPower()
    {
        if(gScript.powerON == true)
        {

            return true;

        }
        else
        {

            return false;
        }
    }

}
