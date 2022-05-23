using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard_Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] LayerMask layerFloor;
    
    Animator anim;
    Rigidbody rb;

    Vector3 playerToMouse;
    Vector3 click_position;

    public GameManager GameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetDirection();
    }

    IEnumerator Move()
    {     
        while (true)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, click_position, speed * Time.deltaTime );

            transform.position = newPos;

            if (newPos == click_position)
            {
                break;
            }
            yield return null;
        }
    }

    void SetDirection()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerFloor))
            {
                click_position = hit.point;
                playerToMouse = hit.point - transform.position;
                playerToMouse.y = 0;
                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
                rb.MoveRotation(newRotation);

                StartCoroutine(Move());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Victory")){GameManager.Victory();}
    }
}