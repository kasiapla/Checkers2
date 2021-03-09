using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    private Square currentSquare;
    private BoardController board;

    void Start()
    {
        board = BoardController.instance;
        currentSquare = board.GetClosestSquare(this);
        name = currentSquare?.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

