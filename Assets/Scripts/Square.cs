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

public class Square : MonoBehaviour, IEventSystemUser
{
    [SerializeField] private SquareOccupation occupation;
    [SerializeField] private SquareStatus status;
    [SerializeField] private Square[] upperSquares;
    [SerializeField] private Square[] lowerSquares;
    [SerializeField] private Material material1;
    [SerializeField] private Material material2;
    [SerializeField] private MeshRenderer mesh;
    bool _isHighlighted = false;

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
    public bool IsHighlighted
    {
        get { return _isHighlighted; }
    }
    public void ChangeSquareColor()
    {
        mesh.material = material2;
        _isHighlighted = true;
    }

    public void TurnHighlightOff()
    {
        mesh.material = material1;
        _isHighlighted = false;
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

    public void OnGameEvent(GameEventType type, object obj)
    {

    }

    public void MarkAsFree()
    {
        occupation = SquareOccupation.Free;
    }

    public void MarkAsOccupied(CheckerColor checkerColor)
    {
        if (checkerColor == CheckerColor.White) occupation = SquareOccupation.WhiteCheckerOn;
        else occupation = SquareOccupation.BlackCheckerOn;
    }

}
