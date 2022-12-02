using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public GameObject coin;
    float degreespersecond = 180;
    // Start is called before the first frame update
    void Start()
    {
        coin = this.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coin.transform.Rotate(new Vector3(0, 0, degreespersecond) * Time.deltaTime);
    }

   

}
