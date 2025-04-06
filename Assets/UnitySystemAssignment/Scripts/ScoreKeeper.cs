using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject BoxManager;
    public TextMeshProUGUI score;
    public int currentScore;

    // Update is called once per frame
    void Update()
    {
        score.text = ("Score: " + currentScore.ToString());

        if (currentScore == 3)
        {
            BoxManager.GetComponent<BoxManagerSpawner>().CallGoldenBox.Invoke();
        }
    }
}
