using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManagerSpawner : MonoBehaviour
{
    public List<GameObject> Boxes;
    public GameObject Prefab;
    int key;
    public int howmany = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            spawnBoxes(howmany);
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
}

