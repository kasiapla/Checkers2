using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightPossibleMoves : MonoBehaviour, IEventSystemUser
{
    List<Square> _highlightedSquares;

    void Awake()
    {
        GameEventSystem.RegisterUser(this);
    }

    public void OnGameEvent(GameEventType type, object obj)
    {
        switch (type)
        {
            case GameEventType.DisplayPossibleMoves:
                DisplayPossibleMoves((Square)obj);
                break;
            case GameEventType.ClearHighlight:
            case GameEventType.ChangePlayerTurn:
                ClearHighlights();
                break;
        }
    }

    public void DisplayPossibleMoves(Square clickedSquare)
    {
        ClearHighlights();
        CalculatePossibleMoves(clickedSquare);
        HighlightSquares();
    }

    List<Square> CheckPossibleMoves(Square[] squaresToCheck)
    {
        List<Square> possibleMoves = new List<Square>();
        for (int i = 0; i < squaresToCheck?.Length; i++)
        {
            Square currentSquare = squaresToCheck[i];
            if (currentSquare == null) continue;
            if (currentSquare.Occupation == SquareOccupation.Free) possibleMoves.Add(currentSquare);
        }
        return possibleMoves;
    }

    void ClearHighlights()
    {
        for (int i = 0; i < _highlightedSquares?.Count; i++)
        {
            _highlightedSquares[i]?.TurnHighlightOff();
        }
        _highlightedSquares = null;
    }

    void CalculatePossibleMoves(Square clickedSquare)
    {
        if (clickedSquare == null) return;
        switch (clickedSquare.Occupation)
        {
            case SquareOccupation.Free:
                break;
            case SquareOccupation.WhiteCheckerOn:
                if(GameFlow.PlayerTurn == PlayerTurn.PlayerOne)
                _highlightedSquares = CheckPossibleMoves(clickedSquare.UpperSquares);
                break;
            case SquareOccupation.BlackCheckerOn:
                if (GameFlow.PlayerTurn == PlayerTurn.PlayerTwo)
                    _highlightedSquares = CheckPossibleMoves(clickedSquare.LowerSquares);
                break;
            default:
                break;
        }
    }

    void HighlightSquares()
    {
        for (int i = 0; i < _highlightedSquares?.Count; i++)
        {
            _highlightedSquares[i]?.ChangeSquareColor();
        }
    }
}