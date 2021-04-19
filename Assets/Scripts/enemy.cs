using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]private bool RADAR = false;
    public GameObject target;
    private int multi;

    private void Start()
    {
        GetComponent<Rigidbody>();
        var multiplier = Random.Range(14500, 15000);
        multi = multiplier;
    }


    private void Update()
    {
        //car move
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (-3 * Time.deltaTime));


        if(RADAR == true)
        {
            GetComponent<Rigidbody>().AddForce((target.transform.position - transform.position) * multi * Time.smoothDeltaTime);

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("radar") && other.isTrigger)
        {
            RADAR = true;
        }

        if ((other.gameObject.CompareTag("escord") && other.isTrigger) || (other.gameObject.CompareTag("Player") && other.isTrigger))
        {
            Destroy(GetComponent<Collider>());
            Destroy(gameObject, 1);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        {
            if (other.gameObject.CompareTag("radar") && other.isTrigger)
            {
                RADAR = false;
            }
        }
    }
}
