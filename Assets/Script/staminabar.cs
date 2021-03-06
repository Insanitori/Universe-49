using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class staminabar : MonoBehaviour
{
    public Slider staminaBar;

    public float max = 100;
    public float cur;

    private WaitForSeconds reg = new WaitForSeconds(0.1f);
    // Start is called before the first frame update
    private Coroutine regn;
    public static staminabar instance;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        cur = max;
        staminaBar.maxValue = max;
        staminaBar.value = max;
    }

    public void useeStamina(float amount)
    {
        if(cur - amount >= 0)
        {
            cur -= amount;
            staminaBar.value = cur;

            if (regn != null)
            {
                StopCoroutine(regn);
            }

            regn = StartCoroutine(regStamina());
        }
        else
        {
            Debug.Log("Not enough stamina.");
        }
    }

    private IEnumerator regStamina()
    {
        yield return new WaitForSeconds(5);

        while(cur < max)
        {
            cur += max / 100;
            staminaBar.value = cur;
            yield return reg;
            Debug.Log("Regn");
        }
        regn = null;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        
    }
}
