using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineGrower : MonoBehaviour
{

    public AnimationCurve curve;
    public float minSize = 0;
    public float maxSize = 1;
    public float t;
    public Transform apple;
    public Transform cookie;
    //public void StartGrow()
    //{

    //    StartCoroutine(Grow());

    //}


    public IEnumerator Grow()
    {
        apple.localScale = Vector3.zero;
        cookie.localScale = Vector3.zero;
        transform.localScale = Vector3.zero;
        // grow the tree
        t = 0;
        //transform.localScale = Vector3.Lerp(Vector3.one * minSize, Vector3.one * maxSize, curve.Evaluate(t));
        yield return new WaitForSeconds(Random.Range(.05f, .5f));
        while (t < 1)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }

        //grow the apple
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            apple.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }
        // 2 could also be replaced with a Random.Range(.05f, .5f) for random wait time
        yield return new WaitForSeconds(Random.Range(.05f, .5f));

        //grow the cookie
        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            cookie.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }

    }
}
