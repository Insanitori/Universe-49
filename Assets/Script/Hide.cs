using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject player;

    private float yaw = 0.0f;
    private float speedH = 5.0f;
    private float turning = 30.0f;

    //public bool isHidden;
    public Movement Move;
    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Move.isHidden == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //isHidden
                camera2.SetActive(true);
                camera1.SetActive(false);
                player.SetActive(false);

                yaw += speedH * Input.GetAxis("Mouse X");
                if (yaw > turning)
                {
                    yaw = turning;
                }
                else if (yaw < -turning)
                {
                    yaw = -turning;
                }
                camera2.transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
            }
            else
            {
                camera2.SetActive(false);
                camera1.SetActive(true);
                player.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Move.isHidden = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Move.isHidden = false;
    }

}
