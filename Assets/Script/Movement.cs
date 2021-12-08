using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private float speed = 5.0f;

    public Camera camera1;

    private Vector3 moveDirection = Vector3.zero;
    public Transform camTran;

    private staminabar instance;
    public bool isRunning;
    public bool isHidden;

    public float unlock;

    public int hurt;
    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
        isHidden = false;
        unlock = 0;
        hurt = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hurt == 5)
        {
            SceneManager.LoadScene("Death");
        }

        float hInport = Input.GetAxis("Horizontal");
        float vInport = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * hInport);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * vInport);

        moveDirection = new Vector3(hInport, 0, vInport);
        moveDirection = camTran.TransformDirection(moveDirection);
        moveDirection *= speed;

        if(isRunning == true)
        {
            speed = 15.0f;
        }

        if(isRunning == false)
        {
            speed = 5.0f;
        }


        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, camera1.transform.localEulerAngles.y, transform.localEulerAngles.z);
        if (staminabar.instance.cur >= 5)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                isRunning = true;
                instance = GetComponent<staminabar>();
                staminabar.instance.useeStamina(100/5 * Time.deltaTime);
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
