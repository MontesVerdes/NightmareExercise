using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask layerFloor;
    
    Animator anim;
    Rigidbody rb;

    Vector3 movement;
    float h;
    float v;

    public GameManager GameManager;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerInput();
        Move();
        Animating();
        Turning();
    }

    void PlayerInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void Move()
    {
        movement = new Vector3(h,0,v);
        movement.Normalize();

        rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }

    void Animating()
    {
        if(h!=0 || v!=0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
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