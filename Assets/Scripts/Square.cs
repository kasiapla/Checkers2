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
    [SerializeField] private Material material1;
    [SerializeField] private Material material2;
    [SerializeField] private MeshRenderer mesh;

    public SquareOccupation Occupation
    {
        get { return occupation; }
    }

    public Square[] UpperSquares
    {
        get { return upperSquares; }
    }

    public Square[] LowerSquares
    {
        get { return lowerSquares; }
    }
    public void ChangeSquareColor()
    {
        mesh.material = material2;
    }

    public void TurnHighlightOff()
    {
        mesh.material = material1;
    }

    public void CheckForChecker()
    {
        switch (occupation)
        {
            case SquareOccupation.WhiteCheckerOn:
                break;
            case SquareOccupation.BlackCheckerOn:
                break;
        }
    }
}
