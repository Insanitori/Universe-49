using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject Cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hInport = Input.GetAxis("Horizontal");
        float vInport = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * hInport);
        transform.Translate(Vector3.left * Time.deltaTime * speed * vInport);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);


    }
}
