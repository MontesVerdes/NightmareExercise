using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask layerFloor;
    
    Animator anim;
    Rigidbody rb;

    public GameManager GameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Turning();
    }

    void Move()
    {     
        if(Input.GetKey("w"))
        {
            rb.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
        }
    }

    void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerFloor))
        {
            Vector3 playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Victory")){GameManager.Victory();}
    }
}