using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour, IEventSystemUser
{
    [SerializeField] Transform _board;
    public static BoardController instance;
    public List<Square> _squares = new List<Square>();

    private void Awake()
    {
        GameEventSystem.RegisterUser(this);
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
            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                resultSquare = currentSquare;
            }
        }
        return resultSquare;
    }

    void Update()
    {
        
    }

    public void OnGameEvent(GameEventType type, object obj) { }
}


