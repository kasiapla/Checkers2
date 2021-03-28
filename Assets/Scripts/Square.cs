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
    [SerializeField] public SquareOccupation occupation { get; }
    [SerializeField] public SquareStatus status { get; }
    [SerializeField] public Square[] upperSquares { get; }
    [SerializeField] public Square[] lowerSquares { get; }
}
