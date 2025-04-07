using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public GameObject BoxManager;
    public TextMeshProUGUI score;
    public float currentScore;
    float tempscore;
   
    // Update is called once per frame
    void Update()
    {
        
        score.text = ("Score: " + currentScore.ToString());
      
        if (0 == currentScore % 5)
        {
            unityevent();
        }
    }
    void unityevent()
    {
        currentScore += 1;
        BoxManager.GetComponent<BoxManagerSpawner>().CallGoldenBox.Invoke();
    }

}
