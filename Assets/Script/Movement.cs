using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float speed;

    public Camera camera1;

    private Vector3 moveDirection = Vector3.zero;
    public Transform camTran;

    private staminabar instance;
    // Start is called before the first frame update
    void Start()
    {

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


        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, camera1.transform.localEulerAngles.y, transform.localEulerAngles.z);

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            instance = GetComponent<staminabar>();
            staminabar.instance.useeStamina(15);
        }
    }
}
