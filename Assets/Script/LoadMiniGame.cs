using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMiniGame : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;

    public GameObject cam1;

    public bool skillCheck;
    public Movement Move;
    void Start()
    {
        //SceneManager.LoadScene("Skill Check", LoadSceneMode.Additive);
        skillCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(skillCheck == true)
        {
            cam1.SetActive(true);
        }
        else if(skillCheck == false)
        {
            cam1.SetActive(false);
        }

        if((player.transform.position - this.transform.position).sqrMagnitude < 3 * 3)
        {
            if (Input.GetKeyDown(KeyCode.Space) && skillCheck == false)
            {
                skillCheck = true;
                GameObject.Find("Player").GetComponent<Movement>().enabled = false;
                GameObject.Find("Player Camera").GetComponent<CameraPlayer>().enabled = false;

            }
            else if(Input.GetKeyDown(KeyCode.Space) && skillCheck == true)
            {
                skillCheck = false;
                GameObject.Find("Player").GetComponent<Movement>().enabled = true;
                GameObject.Find("Player Camera").GetComponent<CameraPlayer>().enabled = true;
            }
        }
    }
}
