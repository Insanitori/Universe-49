using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float tempo;

    public bool hasStarted;
    public LoadMiniGame MG;
    public CountDown CD;

    private Vector3 starting;

    // Start is called before the first frame update
    void Start()
    {
        tempo = tempo / 60f;
        starting = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            if(Input.anyKeyDown && MG.skillCheck == true && CD.timerIsRunning == false)
            {
                hasStarted = true;
            }
        }
        else
        {
            if (MG.skillCheck == true && CD.timerIsRunning == false)
            {
                transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
            }
            else if (CD.timerIsRunning == true)
            {
                transform.position = starting;
            }

            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                hasStarted = false;
                transform.position = starting;
                CD.timeRemaining = 20;
                CD.timerIsRunning = true;
            }
        }
    }
}
