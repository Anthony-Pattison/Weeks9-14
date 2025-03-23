using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KitClock : MonoBehaviour
{
    public Transform MinuteHand;
    public Transform HourHand;

    public float timeAnHourTakes = 1;

    public float t;
    public int hour = 0;

    public UnityEvent<int> OnTheHour;

    Coroutine RunTheClock;
    IEnumerator CurrentlyRunningClock;

    private void Start()
    {
        RunTheClock = StartCoroutine(MakeTheClockRun());
    }

    // in order for a coroutine to start after another coroutine ended it must be in its own
    // coroutine to be able to use the yield return
    IEnumerator MakeTheClockRun()
    {
        while (true)
        {
            CurrentlyRunningClock = MoveTheHandsForAnHour();
            yield return  StartCoroutine(CurrentlyRunningClock);
        }
    }

    IEnumerator MoveTheHandsForAnHour()
    {
        t = 0;

        while (t < timeAnHourTakes)
        {
            t += Time.deltaTime;
            MinuteHand.Rotate(0, 0, (360 / timeAnHourTakes * Time.deltaTime) * -1);
            HourHand.Rotate(0, 0, (30 / timeAnHourTakes * Time.deltaTime) * -1);

            
            yield return null;
        }
        hour++;
        if (hour == 13)
        {
            hour = 1;
        }
        
        OnTheHour.Invoke(hour);

    }

    public void StopTheClock()
    {
        if (RunTheClock != null)
        {
            // StopAllCoroutines() would also work of this to stop both the movement and the restarting of the 
            // clock movement, however its would stop every single coroutine that is currently running
            // which is not very efficient

            StopCoroutine(RunTheClock);
            StopCoroutine(CurrentlyRunningClock);

        }
    }
}
