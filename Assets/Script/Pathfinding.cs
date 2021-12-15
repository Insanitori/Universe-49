using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public Transform[] points;
    public Transform[] follow;

    public Movement Move;

    private NavMeshAgent nav;
    private int destPoint;
    private int followPoint;

    private float zoomies = 8.0f;
    public GameObject player;

    private AudioSource humming;
    public AudioSource laughing;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        humming = GetComponent<AudioSource>();

        humming.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Move.isHidden == true)
        {
            if (!nav.pathPending && nav.remainingDistance < 0.5)
            {
                GoToNextPoint();
            }
        }
        else if (Move.isHidden == false)
        {
            if ((player.transform.position - this.transform.position).sqrMagnitude < 15 * 15)
            {
                //transform.position = (Vector3.MoveTowards(transform.position, player.transform.position, (zoomies * Time.deltaTime)));
                humming.Pause();
                laughing.Play();
                nav.SetDestination(player.transform.position);
            }
            else if(!nav.pathPending && nav.remainingDistance < 1)
            {
                LookForPlayer();
                laughing.Stop();
                if (!humming.isPlaying)
                {
                    humming.Play();
                }
            }
        }
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        nav.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    void LookForPlayer()
    {
        if (follow.Length == 0)
        {
            return;
        }
        nav.destination = follow[followPoint].position;
        followPoint = (followPoint + 1) % follow.Length;
    }
}

//Figure out how to make the monster chase you if you get close even if it's in the middle of pathfinding
//also, try adding yield; to the end of the while loop and seeing if there's any difference and seeing if it crashes
