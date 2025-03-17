using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LerpGrower : MonoBehaviour
{
    public AnimationCurve curve;
    public float minSize = 0;
    public float maxSize = 1;
    public float t;
    public bool startGrowning;

    private void Update()
    {
     
        if (startGrowning)
        {
            Grow();
        }
       
    }

    public void StartGrwoing()
    {
        startGrowning = true;
        t = 0;
    }
    public void Grow()
    {

        transform.localScale = Vector3.one * maxSize * curve.Evaluate(t);
        //transform.localScale = Vector3.Lerp(Vector3.one * minSize, Vector3.one * maxSize, curve.Evaluate(t));
        if (t < 1)
        {
            t += Time.deltaTime;
        }
        else
        {
            startGrowning = false;
        }
    }
}

