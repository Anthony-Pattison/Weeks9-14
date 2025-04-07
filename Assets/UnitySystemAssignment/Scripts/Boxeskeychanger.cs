using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Boxeskeychanger : MonoBehaviour
{
    IEnumerator GoldenBoxIsMoving;

    public bool TimeToDelete = false;
    public int BoxKey;
    public float t = 1;
    public bool StartShrink;
    public AnimationCurve curve;

    public void Spawngoldenbox(GameObject t)
    {
        StartCoroutine(StartOneGoldenBox(t));
    }

    public void Stopgoldenbox(GameObject t)
    {

        Debug.Log("Stoping the box");
        StopCoroutine(GoldenBoxIsMoving);

    }
    public void StartShink(GameObject t)
    {
        StartCoroutine(enteredbox(t));
    }
    public IEnumerator enteredbox(GameObject c)
    {
        Vector2 scale = c.transform.localScale;
        StartShrink = true;
        while (t > 0) { 
        
            t -= 0.01f * Time.deltaTime;
            scale.x = t;
            scale.y = t;
            Debug.Log(scale);
            c.transform.localScale = scale;
            yield return null;
        }
        StartShrink = false;
    }

    public IEnumerator StartOneGoldenBox(GameObject t)
    {

        yield return GoldenBoxIsMoving = GoldenBoxMovment(t);
    }

    public IEnumerator GoldenBoxMovment(GameObject goldenbox)
    {
        Vector2 goldenboxPos = goldenbox.transform.position;
        goldenboxPos.y = Random.Range(-3.20f,3.21f);
        goldenboxPos.x = -12;
        goldenbox.transform.position = goldenboxPos;
        Vector2 screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);

        while (screenpoint.x <= (Screen.width / 2))
        {
            screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);

            t += 0.5f * Time.deltaTime;
            goldenboxPos.x += t * Time.deltaTime;
            goldenbox.transform.position = goldenboxPos;
            yield return null;
        }

        yield return new WaitForSeconds(2);

        while (screenpoint.x <= (Screen.width + 5))
        {
            screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);

            t += 0.5f * Time.deltaTime;
            goldenboxPos.x += t * Time.deltaTime;
            goldenbox.transform.position = goldenboxPos;
            yield return null;
        }
        TimeToDelete = true;
    }

}
