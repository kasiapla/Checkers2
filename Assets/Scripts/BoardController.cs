using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] Transform _board;
    public static BoardController instance;
    List<Square> _squares = new List<Square>();

    private void Awake()
    {
        instance = this;
        if (_board == null) return;

        for (int lineIndex = 0; lineIndex < _board.childCount; lineIndex++)
        {
            Transform lines = _board.GetChild(lineIndex);
            if (lines == null) break;
            for (int squareIndex = 0; squareIndex < lines.childCount; squareIndex++)
            {
                Transform square = lines.GetChild(squareIndex);
                if (square == null) break;
                _squares.Add(square.GetComponent<Square>());
            }
        }

        Debug.Log("squares number: " + _squares.Count);
        Debug.Log("square 6" + _squares[5].gameObject.name);
    }

    public Square GetClosestSquare(Checker checker)
    {
        if (checker == null) return null;
        Vector3 checkerPosition = checker.transform.position;
        float smallestDistance = 10000f;
        Square resultSquare = null;

        for (int i = 0; i < _squares.Count; i++)
        {
            Square currentSquare = _squares[i];
            if (currentSquare == null) continue;
            Vector3 squarePosition = currentSquare.transform.position;
            float distance = Vector3.Distance(checkerPosition, squarePosition);
            if (distance < smallestDistance) { 
                smallestDistance = distance;
                resultSquare = currentSquare;            
            }
        }
        return resultSquare;
    }

    void ClickSquare()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < _squares.Count; i++)
            {

            }
        }

    }

    void DisplayPossibleMoves(Square clickedSquare)
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
            //tu bedzie zmiana koloru jak wymysle jak ja zrobić
        }
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
}
