using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoodGhostMovement : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform playerTransform;

    bool goFollow = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){goFollow = true;}
    }

    void followPlayer()
    {
        if(goFollow == true)
        {
            agent.SetDestination(playerTransform.position);

            agent.stoppingDistance = 2f;
        }
    }
}
