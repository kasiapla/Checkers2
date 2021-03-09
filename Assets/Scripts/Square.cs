using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SquareOccupation
{
    Free,
    WhiteCheckerOn,
    BlackCheckerOn
}

public enum SquareStatus
{
    None,
    WhitePromotion,
    BlackPromotion
}

public class Square : MonoBehaviour
{
    [SerializeField] private SquareOccupation occupation;
    [SerializeField] private SquareStatus status;
    [SerializeField] private Square[] upperSquares;
    [SerializeField] private Square[] lowerSquares;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
