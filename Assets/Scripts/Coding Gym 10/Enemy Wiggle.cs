using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class EnemyWiggle : MonoBehaviour
{
    public AnimationCurve curve;
    float maxSize = 0.8f;
   
    public float t;
    public bool turn;
  public IEnumerator OnBatHit;
    public Button hit;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    IEnumerator GrowBat()
    {
        
        t = 0;
        turn = false;
        while (t < 1)
        {
            
            t += Time.deltaTime;
            transform.localScale = Vector3.one * maxSize * curve.Evaluate(t);
            yield return null;
        }
        
    }
    public void StartAttack()
    {
        OnBatHit = GrowBat();
        StartCoroutine(OnBatHit);
    }
    
}
