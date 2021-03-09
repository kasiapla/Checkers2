using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckers : MonoBehaviour
{
    [SerializeField] Transform _blackCheckers;
    [SerializeField] Transform _whiteCheckers;
    const int CHECKERS_AMOUNT_PER_PLAYER = 12;

    private void Awake()
    {
        List<Checker> blackCheckers = new List<Checker>();
        List<Checker> whiteCheckers = new List<Checker>();

        for (int i = 0; i < CHECKERS_AMOUNT_PER_PLAYER; i++)
        {
            blackCheckers.Add(_blackCheckers.GetChild(i).GetComponent<Checker>());
            whiteCheckers.Add(_whiteCheckers.GetChild(i).GetComponent<Checker>());
        }

        Debug.Log("black checkers amount: " + blackCheckers.Count);
        Debug.Log("white checkers amount: " + whiteCheckers.Count);
    }

}
