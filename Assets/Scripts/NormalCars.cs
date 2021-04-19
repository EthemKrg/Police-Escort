using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCars : MonoBehaviour
{
    private int speed;
    private GameObject X;
    public List<GameObject> vehicles;

    private void Start()
    {
        // for car prefab
        var number = Random.Range(0,28);
        X = vehicles[number];
        // for car speed
        var speedNumber = Random.Range(3, 5);
        speed = speedNumber;

        // instantiate random car
        var car = Instantiate(X, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        car.transform.parent = gameObject.transform;
    }
    private void Update()
    {
        //car move
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("escord") && other.isTrigger) ||
            (other.gameObject.CompareTag("Player") && other.isTrigger) || (other.gameObject.CompareTag("enemy") && other.isTrigger))
        {
            Destroy(GetComponent<Collider>());
            Destroy(GetComponent<Collider>());

            speed = 0;
            Destroy(gameObject, 1);
        }
    }
}
