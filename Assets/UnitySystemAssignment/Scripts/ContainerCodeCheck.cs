using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (GetComponent<SpriteRenderer>().bounds.Contains(Spawnedboxes[i].transform.position) &&Spawnedboxes[i].GetComponent<Boxeskeychanger>().BoxKey == ContainerKey)
            {
                Debug.Log("Working");
                ScoreManager.GetComponent<ScoreKeeper>().currentScore++;
                BoxManager.GetComponent<BoxManagerSpawner>().DestroyObject(Spawnedboxes[i]);
            }
        }
    }
}
