using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EXIT : MonoBehaviour
{
    public Movement Move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Move.unlock >= 90)
            {
                Debug.Log("You may proceed");
                SceneManager.LoadScene("Escape");
            }
            else
            {
                Debug.Log("You do not have enough");
            }
        }
    }
}
