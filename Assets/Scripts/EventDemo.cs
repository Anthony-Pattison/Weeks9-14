using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventDemo : MonoBehaviour
{
    public UnityEvent OnTimerFinish;
    public RectTransform Egg;
    public float timerLength = 2;
    float t;
    private void Update()
    {
        t += 1 * Time.deltaTime;
        if (t > timerLength)
        {
            t = 0;
            OnTimerFinish.Invoke();
        }
        //if (t < timerLength)
        //{
        //    t += 1 * Time.deltaTime;

        //}
        //else
        //{
        //    OnTimerFinish.Invoke();
        //}
    }
    public void MouseEntered()
    {
        Debug.Log("Mouse just entered");
        Egg.localScale = Vector3.one * 1.2f;
    }
    public void MouseExit()
    {
        Debug.Log("Mouse just left");
        Egg.localScale = Vector3.one;
    }

}