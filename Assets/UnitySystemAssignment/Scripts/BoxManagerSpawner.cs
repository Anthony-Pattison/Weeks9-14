using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        if (Input.GetKeyDown("space"))
        {
            //GoldenBox();
        }
        if (Boxes.Count == 0)
        {
            spawnBoxes(howmany);
            howmany++;
        }
        if (goldenbox != null)
        {
            if (goldenbox.GetComponent<Boxeskeychanger>().TimeToDelete)
            {
                DestroyObject(goldenbox);
            }
        }
    }

    private void spawnBoxes(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject NewObject = Instantiate(Prefab);


            key = Random.Range(1, 4);
            NewObject.GetComponent<Boxeskeychanger>().BoxKey = key;
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

            Vector2 PrefabPos = Vector2.zero;
            PrefabPos.x = 1 * Random.Range(-10f, 10f);
            PrefabPos.y = 1 * Random.Range(-4f, 4f);

            NewObject.transform.position = PrefabPos;

            Boxes.Add(NewObject);
        }
    }

    public void DestroyObject(GameObject t)
    {
        Destroy(t);
        Boxes.Remove(t);
    }

    public void GoldenBox()
    {
        goldenbox = Instantiate(Prefab);
        Boxes.Add(goldenbox);

        goldenbox.GetComponent<Boxeskeychanger>().BoxKey = 4;
        goldenbox.GetComponent<Boxeskeychanger>().Spawngoldenbox(goldenbox);

    }
}

