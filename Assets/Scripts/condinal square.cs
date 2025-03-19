using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condinalsquare : MonoBehaviour
{
    public float t;

    // Update is called once per frame
    public void Grow()
    {
        if (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * t;
           
        }
    }
    
}
