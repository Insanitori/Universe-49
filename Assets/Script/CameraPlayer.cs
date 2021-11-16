using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public GameObject Player;

    public float speedH;
    public float speedV;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Vector3 Offset = new Vector3(0, 1, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + Offset;
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);


    }
}
