using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitChime : MonoBehaviour
{
    public KitClock clock;

    AudioSource audioSource;
    public AudioClip chimeSFX;

    public void Start()
    {
        clock.OnTheHour.AddListener(ChimeTheHour);
        audioSource = GetComponent<AudioSource>();
    }
    public void Chime()
    {
        Debug.Log("Chiming !");
    }

    public void ChimeTheHour(int hour)
    {
        Debug.Log("Chiming ! " +hour+ " Big dog");
        StartCoroutine(ChimeTheHourCorutine(hour));
    }

    private void ChimeOnce()
    {
        audioSource.PlayOneShot(chimeSFX);
    }

    IEnumerator ChimeTheHourCorutine(int hour)
    {
        while(hour > 0)
        {
            ChimeOnce();
            yield return new WaitForSeconds(chimeSFX.length);
            hour--;
        }
        
    }
}
