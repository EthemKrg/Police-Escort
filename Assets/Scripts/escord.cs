using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escord : MonoBehaviour
{
    [SerializeField] private float speed = 0;


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.deltaTime));

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy") && other.isTrigger)
        {
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Collider>());

            speed = 0;
            Destroy(gameObject, 1);
        }
    }
}
