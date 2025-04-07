using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerCodeCheck : MonoBehaviour
{
    // this value gets changes in the inspector
    public int ContainerKey;

    public GameObject BoxManager;
    public GameObject ScoreManager;
    List<GameObject> Spawnedboxes;
    
    // Start is called before the first frame update
    void Start()
    {
        // sets the box list from the boxmanager to a value
        Spawnedboxes = BoxManager.GetComponent<BoxManagerSpawner>().Boxes;
    }

    // Update is called once per frame
    void Update()
    {
        // runs through the list of boxes
        for (int i = 0; i < Spawnedboxes.Count; i++)
        {
            // if a box is inside of a container
            if (GetComponent<SpriteRenderer>().bounds.Contains(Spawnedboxes[i].transform.position))

            {
                // does the keynumber match
                if (Spawnedboxes[i].GetComponent<Boxeskeychanger>().BoxKey == ContainerKey)
                {
                    // start shrinking the box
                    Spawnedboxes[i].GetComponent<Boxeskeychanger>().StartShink(Spawnedboxes[i]);
                    // if the shrink coroutine is done
                    if (!Spawnedboxes[i].GetComponent<Boxeskeychanger>().StartShrink)
                    {
                        // score goes up by one
                        ScoreManager.GetComponent<ScoreKeeper>().currentScore++;
                        // call destroy function
                        BoxManager.GetComponent<BoxManagerSpawner>().DestroyObject(Spawnedboxes[i]);
                    }
                }
                // if the box that enterned was a golden box
                else if (Spawnedboxes[i].GetComponent<Boxeskeychanger>().BoxKey == 4)
                {
                    //score goes up by two
                    ScoreManager.GetComponent<ScoreKeeper>().currentScore += 2;
                    // call destroy function
                    BoxManager.GetComponent<BoxManagerSpawner>().DestroyObject(Spawnedboxes[i]);
                }
                else if (Spawnedboxes[i].GetComponent<Boxeskeychanger>().BoxKey != ContainerKey)
                {
                    // score goes down
                    ScoreManager.GetComponent<ScoreKeeper>().currentScore--;
                    // call destroy function
                    BoxManager.GetComponent<BoxManagerSpawner>().DestroyObject(Spawnedboxes[i]);
                }
            }
        }

    }
}
