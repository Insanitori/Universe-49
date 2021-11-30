using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float zoomies = 0.02f;
    public GameObject player;
    public Movement Move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * Time.deltaTime * zoomies);

        //hideScript = GetComponent<Hide>();
        if (Move.isHidden == false)
        {
            if ((player.transform.position - this.transform.position).sqrMagnitude < 15 * 15)
            {
                transform.position = (Vector3.MoveTowards(transform.position, player.transform.position, zoomies /* Time.deltaTime*/));
            }
        }
    }
}
