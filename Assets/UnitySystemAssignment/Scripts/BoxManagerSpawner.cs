using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngineInternal;

public class BoxManagerSpawner : MonoBehaviour
{
    public List<GameObject> Boxes;
    public GameObject Prefab;
    GameObject goldenbox;
    
    int key;
    public int howmany = 3;

    public UnityEvent CallGoldenBox;
    // Update is called once per frame
    void Update()
    {
        // if the list of boxes are empty then respawn the boxes
        if (Boxes.Count == 0)
        {
            spawnBoxes(howmany);
            // extra box eachtime the function runs
            howmany++;
        }
        // if there is a golden box on screen and if the time to delete function are true
        if (goldenbox != null)
        {
            if (goldenbox.GetComponent<Boxeskeychanger>().TimeToDelete)
            {
                DestroyObject(goldenbox);
            }
        }
    }
    // spawn boxes function
    private void spawnBoxes(int amount)
    {
        // runs a for loop for the amont for boxes that is requested from the varible howmany
        for (int i = 0; i < amount; i++)
        {
            // make a prefab
            GameObject NewObject = Instantiate(Prefab);

            // gives the box value from 1 and 3 Random.Range is not manvalue inclusive a 4 will never be rolled
            key = Random.Range(1, 4);
            // set key value
            NewObject.GetComponent<Boxeskeychanger>().BoxKey = key;
            // gives the box a color based on the key value
            if (key == 1)
            {
                NewObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            else if (key == 2)
            {
                NewObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (key == 3)
            {
                NewObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
            // give the box a position that is on screen
            Vector2 PrefabPos = Vector2.zero;
            PrefabPos.x = 1 * Random.Range(-8f, 8f);
            PrefabPos.y = 1 * Random.Range(-3f, 3f);
            // give position
            NewObject.transform.position = PrefabPos;
            // add to the list with the other boxes
            Boxes.Add(NewObject);
        }
    }
    // the destroy function
    public void DestroyObject(GameObject t)
    {
        // destroys the prefab
        Destroy(t);
        // remove it from the list so the spot is not empty
        Boxes.Remove(t);
    }
    // spawns the golden box and adds it to the list
    public void GoldenBox()
    {
        // make it a prefab
        goldenbox = Instantiate(Prefab);
        // add to the list
        Boxes.Add(goldenbox);
        // make it yellow
        goldenbox.GetComponent<SpriteRenderer>().color = Color.yellow;
        // give it the key number 4
        goldenbox.GetComponent<Boxeskeychanger>().BoxKey = 4;
        // runs the coroutine that moves the box
        goldenbox.GetComponent<Boxeskeychanger>().Spawngoldenbox(goldenbox);

    }
}

