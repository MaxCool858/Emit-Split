using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingExpand : MonoBehaviour
{

    public float timeValue = 3;



    public float speed = 10f;
    Vector3 temp;
    Vector3 temp2;
    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            Expand();
        }
        else
        {
            timeValue += 10;
            Destroy(this.gameObject);
        }




    }


    void Expand()
    {

        temp = transform.localScale;

        temp.x += Time.deltaTime * speed;

        transform.localScale = temp;

        temp2 = transform.localScale;

        temp2.z += Time.deltaTime*speed;

        transform.localScale = temp2;


    }

}
