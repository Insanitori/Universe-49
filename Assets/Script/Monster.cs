using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    public Movement Move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Move.hurt += 1;
        }
    }
}
