using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Input.GetKey(KeyCode.F))
        {
            //isHidden
            camera2.enabled = !camera2.enabled;
        }
        else
        {
            camera1.enabled = !camera2.enabled;
        }
    }
}
