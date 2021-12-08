using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesObjective : MonoBehaviour
{

    public bool canBePressed;

    public KeyCode keyToPress;

    public Movement Move;
    // Start is called before the first frame update
    void Start()
    {
        Move = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);
                Move.unlock += 1;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
        {
            canBePressed = false;
        }
    }
}
