using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxeskeychanger : MonoBehaviour
{
    public bool TimeToDelete = false;
    public int BoxKey;
    public float t = 0;
    public void Spawngoldenbox(GameObject t)
    {
        StartCoroutine(GoldenBoxMovment(t));
    }
    public IEnumerator GoldenBoxMovment(GameObject tempBox)
    {
        GameObject goldenbox = tempBox;
        Vector2 goldenboxPos = goldenbox.transform.position;
       
        goldenboxPos.x = -14;
        goldenbox.transform.position = goldenboxPos;
        Vector2 screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);


       
        while (screenpoint.x <= (Screen.width/2))
        {
            screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);
            Debug.Log(screenpoint);
            t += 0.1f * Time.deltaTime;
            goldenboxPos.x += t * Time.deltaTime;
            goldenbox.transform.position = goldenboxPos;
            yield return null;
        }

        yield return new WaitForSeconds(5);

        while (screenpoint.x <= (Screen.width + 5))
        {
            screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);
            Debug.Log(screenpoint);
            t += 0.1f * Time.deltaTime;
            goldenboxPos.x += t * Time.deltaTime;
            goldenbox.transform.position = goldenboxPos;
            yield return null;
        }
        TimeToDelete = true;
    }

}
