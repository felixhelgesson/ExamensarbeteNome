using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class RobotBehaviour : MonoBehaviour
{

    public GameObject gravCircle;
    FollowPath pathFollower;
    public Animator animator;
    public InstantiatePickUp pickup;
    public ParticleSystem smoke;
    public bool dead = false;
    public bool destoryed = false;

    public NavMeshAgent agent;
    public bool activated = false;
    bool patrol = false;
    public bool triggerd = false;
    public Transform triggerTrans;
    public Transform[] patrolPoints;
    private int currentPatrolPoint = 0;

    public AudioClip sparks;
    AudioSource aS;

    void Start()
    {
        animator = GetComponent<Animator>();
        aS = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (dead && destoryed)
        {
            activated = false;
            Smoke();
            animator.enabled = false;
            Destroy(gravCircle);
            Destroy(GameObject.Find("key_geo"));
            Invoke("SpitOut", 5);
            dead = true;
            destoryed = false;
            aS.Stop();
            aS.PlayOneShot(sparks);

        }
        patrol = activated && patrolPoints.Length > 0 && triggerd == false && !dead;

        if (patrol)
        {
            if (agent.remainingDistance < 0.5f)
            {

                MoveToNextPoint();
            }
        }
        else if (!dead && triggerd == true)
        {
            MoveToTriggerPoint();
            if (agent.remainingDistance < 0.5f)
            {
                triggerd = false;
            }
        }
    }

    void MoveToNextPoint()
    {
        if (patrolPoints.Length > 0)
        {
            agent.destination = patrolPoints[currentPatrolPoint].position;
            currentPatrolPoint++;
            currentPatrolPoint %= patrolPoints.Length;
        }
    }

    void MoveToTriggerPoint()
    {
        if (triggerTrans != null)
        {
            agent.destination = triggerTrans.position;

        }
    }

    void Smoke()
    {
        Instantiate(smoke, transform);
    }
    void SpitOut()
    {
        //WriteToLog("SpitOut() has been invoked");
        pickup.DropPickUp();
    }
    //public void WriteToLog(string msg)
    //{
    //    string path = @"" + "mOutPut" + ".txt";
    //    using (StreamWriter writer = File.AppendText(path))
    //    {
    //        writer.WriteLine(msg + "\n");
    //        writer.Close();
    //    }
    //}
}
