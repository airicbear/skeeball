using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float width;
    private float height;
    private Rigidbody rigidBody;
    private Vector3 startTouchPosition;

    void Start()
    {
        width = Screen.width / 2;
        height = Screen.height / 2;
        rigidBody = GetComponent<Rigidbody>();
        startTouchPosition = Vector3.zero;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                rigidBody.velocity = Vector3.zero;
                rigidBody.useGravity = false;
                float pos_x = (touch.position.x - width) / width;
                float pos_y = (touch.position.y - height) / height;
                transform.position = new Vector3(pos_x, pos_y - 3.79f, 0.0f);   
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (touch.position.y > startTouchPosition.y)
                {
                    float force_z = (touch.position.y - startTouchPosition.y) / height * 2000;
                    float force_x = (touch.position.x - startTouchPosition.x) / width * 600;
                    Vector3 throwForce = new Vector3(force_x, 0, force_z);
                    rigidBody.AddForce(throwForce);
                    rigidBody.useGravity = true;
                }
            }
        }
    }
}
