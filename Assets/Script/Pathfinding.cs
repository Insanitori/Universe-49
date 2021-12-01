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

    private float zoomies = 0.02f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
                transform.position = (Vector3.MoveTowards(transform.position, player.transform.position, zoomies /* Time.deltaTime*/));
            }

            if(!nav.pathPending && nav.remainingDistance < 0.5)
            {
                LookForPlayer();
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
