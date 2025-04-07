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

    // the coroutine has to be in a function to be called by other game objects
    public void Spawngoldenbox(GameObject t)
    {
        StartCoroutine(StartOneGoldenBox(t));
    }
    // the coroutine has to be in a function to be called by other game objects
    public void Stopgoldenbox(GameObject t)
    {

        Debug.Log("Stoping the box");
        StopCoroutine(GoldenBoxIsMoving);

    }
    // the coroutine has to be in a function to be called by other game objects
    public void StartShink(GameObject t)
    {
        StartCoroutine(enteredbox(t));
    }
    // shrinks the box using a corotine timer
    // passes a box by the container game object
    public IEnumerator enteredbox(GameObject c)
    {
        Vector2 scale = c.transform.localScale;
        // tells the box manager not to destroy game object yet
        StartShrink = true;
        while (t > 0) { 
        // makes the box smaller
            t -= 0.01f * Time.deltaTime;
            scale.x = t;
            scale.y = t;
            Debug.Log(scale);
            c.transform.localScale = scale;
            yield return null;
        }
        // now the box manager can destroy this game object
        StartShrink = false;
    }

    public IEnumerator StartOneGoldenBox(GameObject t)
    {
        // spawns and moves the golden box
        yield return GoldenBoxIsMoving = GoldenBoxMovment(t);
    }

    public IEnumerator GoldenBoxMovment(GameObject goldenbox)
    {
        // making a vector for the gold box
        Vector2 goldenboxPos = goldenbox.transform.position;
        // spawns the box right side of the screen with a random y value
        goldenboxPos.y = Random.Range(-3.20f,3.21f);
        goldenboxPos.x = -12;
        // gives the movement to the golden box
        goldenbox.transform.position = goldenboxPos;
        // used for stoping the box at the halfway point of the screen
        Vector2 screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);

        //while loop to get the box from the left side of the screen to the middle
        while (screenpoint.x <= (Screen.width / 2))
        {
            // need to keep refeshing the screenpoint value so the while stops
            screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);

            t += 0.5f * Time.deltaTime;
            goldenboxPos.x += t * Time.deltaTime;
            goldenbox.transform.position = goldenboxPos;
            yield return null;
        }

        // stops in the middle of the screen so the player can try to pick it up
        yield return new WaitForSeconds(2);

        // continues the movement to the rigt side of the screen
        while (screenpoint.x <= (Screen.width + 5))
        {
            // need to keep refeshing the screenpoint value so the while stops
            screenpoint = Camera.main.WorldToScreenPoint(goldenboxPos);

            t += 0.5f * Time.deltaTime;
            goldenboxPos.x += t * Time.deltaTime;
            goldenbox.transform.position = goldenboxPos;
            yield return null;
        }
        // once it makes it off screen the box will be destroyed
        TimeToDelete = true;
    }

}
