using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float tempo;

    public bool hasStarted;
    public LoadMiniGame MG;

    // Start is called before the first frame update
    void Start()
    {
        tempo = tempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown && MG.skillCheck == true)
            {
                hasStarted = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
        }
    }
}
