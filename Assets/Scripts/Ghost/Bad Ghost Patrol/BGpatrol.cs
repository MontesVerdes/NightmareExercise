using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BGpatrol : MonoBehaviour
{
    public Transform[] points;
    int destinationPoint = 0;
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0) return;

        agent.destination = points[destinationPoint].position;

        if(destinationPoint < 3){destinationPoint = (destinationPoint + 1);}

        else{destinationPoint = 0;}
    }

    // Update is called once per frame
    void Update()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5f){GoToNextPoint();}
    }
    
}