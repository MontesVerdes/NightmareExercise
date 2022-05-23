using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public Transform playerTransform;

    public LayerMask layerWalls;

    Ray ray;
    RaycastHit hit;

    bool seePlayer = false;

    public GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RayToPlayer();
    }

    void RayToPlayer()
    {
        ray = new Ray(transform.position, playerTransform.position-transform.position);

        if(Physics.Raycast(ray,out hit,Mathf.Infinity))
        {
            if(hit.collider.gameObject.CompareTag("Player")){seePlayer = true;}
            else{seePlayer = false;}
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && seePlayer == true){GameManager.GameOver();}
    }
}
