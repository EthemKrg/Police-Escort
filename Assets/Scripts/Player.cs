using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private bool healthBool = true;
    public GameObject radar;
    [SerializeField] private float speed = 0;
    [SerializeField] private int health = 2;


    [Header ("Canvas")]
    public GameObject win;
    public GameObject lose;


    void Update()
    {
        // Moves the player in X 
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (speed * Time.deltaTime));
        radar.transform.position = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemy") && other.isTrigger && healthBool == true)
        {
            healthBool = false;
            StartCoroutine(healthCo());
            if (health == 0)
            {
                speed = 0;
                lose.gameObject.SetActive(true);
            }
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            speed = 0;
            win.gameObject.SetActive(true);
        }
    }

    private IEnumerator healthCo()
    {
        health -= 1;
        yield return new WaitForSeconds(1f);
        healthBool = true;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }


}
