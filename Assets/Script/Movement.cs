using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    private float speed = 4.0f;

    public Camera camera1;

    private Vector3 moveDirection = Vector3.zero;
    public Transform camTran;

    private staminabar instance;
    private bool isRunning;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
    }

    // Update is called once per frame
    void Update()
    {

        float hInport = Input.GetAxis("Horizontal");
        float vInport = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * hInport);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInport);

        moveDirection = new Vector3(hInport, 0, vInport);
        moveDirection = camTran.TransformDirection(moveDirection);
        moveDirection *= speed;

        if(isRunning == true)
        {
            speed = 10.0f;
        }

        if(isRunning == false)
        {
            speed = 4.0f;
        }


        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, camera1.transform.localEulerAngles.y, transform.localEulerAngles.z);
        if (staminabar.instance.cur > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                isRunning = true;
                instance = GetComponent<staminabar>();
                staminabar.instance.useeStamina(.12f);
            }
            else
            {
                isRunning = false;
            }
        }
        else
        {
            isRunning = false;
        }
    }
}
