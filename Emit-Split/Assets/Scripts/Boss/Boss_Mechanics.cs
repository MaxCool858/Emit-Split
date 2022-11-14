using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Mechanics : MonoBehaviour
{
    //Color Changer 
    Color color1 = Color.red;
    Color color2 = Color.green;
    private float Timer = 5.0f;
    private float duration = 1.0f;
    Renderer rend;
    public bool TimerOn = false;


    //Spawn Enemies
    public GameObject exploder_red;
    public GameObject exploder_blue;
    public GameObject exploder_green;



    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<Renderer>();
        TimerOn = true;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("t" + Timer);
       if(TimerOn)
        {
            if (Timer > 0)
            {
               Timer--;
            }
            else
            {
                Timer = 0;
                TimerOn = false;
                ChangeColor();
            }
        
        
        }



    }
    void ChangeColor()
    {
        float Lerp = Mathf.PingPong(Time.time, duration) / duration;
        //  rend.material.color = Color.Lerp(color1, color2, Lerp);
        rend.material.SetColor("_Color", color2);
        Timer = 5.0f;
    }

    void SpawnEnemies()
    {

    }


}
