using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loopsquare : MonoBehaviour
{
    public float t;

    // Update is called once per frame
   public void Grow()
    {
       StartCoroutine(getBigger());
    }
    IEnumerator getBigger()
    {
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * t;
            yield return null;
        }
       
        
    }
}
