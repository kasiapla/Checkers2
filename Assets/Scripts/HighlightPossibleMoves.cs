using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightPossibleMoves : MonoBehaviour, IEventSystemUser
{
    void Awake()
    {
        GameEventSystem.RegisterUser(this);
    }

    public void OnGameEvent(GameEventType type, object obj)
    {
        switch (type)
        {
            case GameEventType.DisplayPossibleMovesLeftClick:
                DisplayPossibleMoves((Square)obj);
                break;
            case GameEventType.DisplayPossibleMovesRightClick:
                DisplayPossibleMoves2(obj as Square);
                break;
            case GameEventType.HighlightPossibleMovesChangeState:
                enabled = !enabled;
                break;
        }
    }

    public void DisplayPossibleMoves(Square clickedSquare)
    {
        if (clickedSquare == null) return;
        List<Square> possibleMoves = new List<Square>();
        switch (clickedSquare.occupation)
        {
            case SquareOccupation.Free:
                break;
            case SquareOccupation.WhiteCheckerOn:
                possibleMoves = CheckPossibleMoves(clickedSquare.upperSquares);
                break;
            case SquareOccupation.BlackCheckerOn:
                possibleMoves = CheckPossibleMoves(clickedSquare.lowerSquares);
                break;
            default:
                break;
        }
        for (int i = 0; i < possibleMoves?.Count; i++)
        {
            possibleMoves[i].ChangeSquareColor();
        }

        clickedSquare.ChangeSquareColor();
    }

    List<Square> CheckPossibleMoves(Square[] squaresToCheck)
    {
        List<Square> possibleMoves = new List<Square>();
        for (int i = 0; i < squaresToCheck.Length; i++)
        {
            Square currentSquare = squaresToCheck[i];
            if (currentSquare == null) continue;
            if (currentSquare.occupation == SquareOccupation.Free) possibleMoves.Add(currentSquare);
        }
        return possibleMoves;
    }

    public void DisplayPossibleMoves2(Square clickedSquare)
    {
        if (clickedSquare == null) return;
        List<Square> possibleMoves = new List<Square>();
        switch (clickedSquare.occupation)
        {
            case SquareOccupation.Free:
                break;
            case SquareOccupation.WhiteCheckerOn:
                possibleMoves = CheckPossibleMoves(clickedSquare.upperSquares);
                break;
            case SquareOccupation.BlackCheckerOn:
                possibleMoves = CheckPossibleMoves(clickedSquare.lowerSquares);
                break;
            default:
                break;
        }
        for (int i = 0; i < possibleMoves?.Count; i++)
        {
            possibleMoves[i].ChangeSquareColor2();
        }

        clickedSquare.ChangeSquareColor2();
    }
}
