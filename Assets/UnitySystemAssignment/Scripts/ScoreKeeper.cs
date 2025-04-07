using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject BoxManager;
    public TextMeshProUGUI score;
    public float currentScore;
   
    // Update is called once per frame
    void Update()
    {
        // displays the score
        score.text = ("Score: " + currentScore.ToString());
      // when score is a x of five run gold box event
        if (0 == currentScore % 5)
        {
            goldboxevent();
        }
    }
    void goldboxevent()
    {
        // stop the event from always running
        currentScore += 1;
        // invoke the event
        BoxManager.GetComponent<BoxManagerSpawner>().CallGoldenBox.Invoke();
    }

}
