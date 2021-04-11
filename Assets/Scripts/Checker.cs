using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    private Square currentSquare;
    private BoardController board;
    private bool isQueen = false;

    void Start()
    {
        board = BoardController.instance;
        currentSquare = board.GetClosestSquare(this);
        name = currentSquare?.name;
    }


}

