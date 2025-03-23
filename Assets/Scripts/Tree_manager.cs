using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_manager : MonoBehaviour
{
    public CoroutineGrower[] Trees;
    
    public void StartGrowingTrees()
    {
        StartCoroutine(GrowAllTheTrees());

    }
    IEnumerator GrowAllTheTrees()
    {
        Debug.Log("Waiting for trees zero");
        yield return StartCoroutine(Trees[0].Grow());
        Debug.Log("Waiting for tree 1");
        yield return StartCoroutine(Trees[1].Grow());
        Debug.Log("Waiting for tree 2");
        yield return StartCoroutine(Trees[2].Grow());
        Debug.Log("Finished all the trees. Dont they look great");

    }
}
