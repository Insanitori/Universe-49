using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Movement Move;

    public static float counter;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        counter = Move.unlock;
        text.text = "Lines of Code Collected: " + counter.ToString() + "/90";

        if(Move.unlock >= 90)
        {
            text.text = "Proceed to the transfer tube to exit this floor";
        }
    }
}
