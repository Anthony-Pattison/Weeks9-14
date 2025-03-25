using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public int howMany = 3;
    public GameObject prefab;
    public GameObject bat;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < howMany; i++) {
            GameObject T = Instantiate(prefab);
            Vector2 pos = T.transform.position;

            pos.x = 1 * Random.Range(-5, 5);
            pos.y = 1 * Random.Range(-5, 5);

            T.transform.position = pos;

            T.GetComponent<Identifyboxscript>().KeyNumber = Random.Range(1, 30);
            if (T.GetComponent<Identifyboxscript>().KeyNumber <= 10)
            {
                T.GetComponent<SpriteRenderer>().color = Color.red;
                Debug.Log("Working");
            }
            if (T.GetComponent<Identifyboxscript>().KeyNumber >= 20)
            {
                T.GetComponent<SpriteRenderer>().color = Color.green;
            }
            bat.GetComponent<TakingMovementAwaywithCoroutine>().moveableBoxes.Add(T);
        }
    }

}
