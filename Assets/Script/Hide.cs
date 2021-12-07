using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject player;

    public float yaw = 0.0f;
    public float speedH = 5.0f;
    public float turning = 30.0f;

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
        if ((player.transform.position - this.transform.position).sqrMagnitude < 2 * 2)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Move.isHidden = true;
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
                camera2.transform.eulerAngles = new Vector3(0.0f, yaw - transform.parent.rotation.eulerAngles.y, 0.0f);
            }
            else
            {
                Move.isHidden = false;
                camera2.SetActive(false);
                camera1.SetActive(true);
                player.SetActive(true);
            }
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        Move.isHidden = true;
    }

    private void OnTriggerStay(Collider other)
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

    private void OnTriggerExit(Collider other)
    {
        Move.isHidden = false;
    }*/

}
