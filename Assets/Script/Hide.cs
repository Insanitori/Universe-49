using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        camera1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.F))
        {
            //isHidden
            camera2.SetActive(true);
            camera1.SetActive(false);
        }
        else
        {
            camera2.SetActive(false);
            camera1.SetActive(true);
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKey(KeyCode.F))
        {
            //isHidden
            camera2.SetActive(true);
            camera1.SetActive(false);
            player.SetActive(false);
        }
        else
        {
            camera2.SetActive(false);
            camera1.SetActive(true);
            player.SetActive(true);
        }
    }
}
