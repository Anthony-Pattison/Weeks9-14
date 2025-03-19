using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
public class ButtonDisasabler : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    bool player1Turn;
    bool player2Turn;
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator EnableAttacks()
    {

        while (player1Turn)
        {
            player1.GetComponent<Button>().interactable = true;
            player1Turn = player1.GetComponent<EnemyWiggle>().turn;
            yield return null;
        }
        while (player2Turn)
        {
            player2.GetComponent<Button>().interactable = true;
            player2Turn = player2.GetComponent<EnemyWiggle>().turn;
            yield return null;
        }

    }
}
