using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeControl : MonoBehaviour
{
    private Touch touch;
    private float touchSpeed = 0.02f;
    void Update()
    {
        //swipe controls
        if (Input.touchCount > 0)
        {

            // if there is more than 1 finger this line set it to 1 finger
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * touchSpeed,
                    transform.position.y,
                    transform.position.z);
            }
        }
    }
}
