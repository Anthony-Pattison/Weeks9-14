using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ContainerCodeCheck : MonoBehaviour
{
    public int ContainerKey;
    public GameObject BoxManager;
    public GameObject ScoreManager;
    List<GameObject> Spawnedboxes;
    
    // Start is called before the first frame update
    void Start()
    {
        Spawnedboxes = BoxManager.GetComponent<BoxManagerSpawner>().Boxes;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Spawnedboxes.Count; i++)
        {
            if (GetComponent<SpriteRenderer>().bounds.Contains(Spawnedboxes[i].transform.position))

            {
                if (Spawnedboxes[i].GetComponent<Boxeskeychanger>().BoxKey == ContainerKey)
                {
                    Spawnedboxes[i].GetComponent<Boxeskeychanger>().StartShink(Spawnedboxes[i]);
                    
                    if (!Spawnedboxes[i].GetComponent<Boxeskeychanger>().StartShrink)
                    {
                        ScoreManager.GetComponent<ScoreKeeper>().currentScore++;
                        BoxManager.GetComponent<BoxManagerSpawner>().DestroyObject(Spawnedboxes[i]);
                    }
                }
                else if (Spawnedboxes[i].GetComponent<Boxeskeychanger>().BoxKey == 4)
                {
                    ScoreManager.GetComponent<ScoreKeeper>().currentScore += 2;
                    BoxManager.GetComponent<BoxManagerSpawner>().DestroyObject(Spawnedboxes[i]);
                }
                else if (Spawnedboxes[i].GetComponent<Boxeskeychanger>().BoxKey != ContainerKey)
                {
                    ScoreManager.GetComponent<ScoreKeeper>().currentScore--;
                    BoxManager.GetComponent<BoxManagerSpawner>().DestroyObject(Spawnedboxes[i]);
                }
            }
        }

    }
}
