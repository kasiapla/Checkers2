using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CheckerColor
{
    White,
    Black
}

public class Checker : MonoBehaviour, IEventSystemUser
{
    private Square currentSquare;
    private BoardController board;
    private bool isQueen = false;
    [SerializeField] private CheckerColor checkerColor;
    [SerializeField] private Material materialWhite;
    [SerializeField] private Material materialBlack;
    [SerializeField] private Material whiteHighlighted;
    [SerializeField] private Material blackHighlighted;
    [SerializeField] private MeshRenderer mesh;


    private Vector3 nextPosition;
    float movementTime;

    public Square CurrentSquare
    {
        get { return currentSquare; }
    }

    void Awake()
    {
        GameEventSystem.RegisterUser(this);
    }

    void Start()
    {
        board = BoardController.instance;
        currentSquare = board.GetClosestSquare(this);
        name = currentSquare?.name;
        nextPosition = transform.position;
    }

    public void MoveChecker(Square nextSquare)
    {
        float checkerPositionY = transform.position.y;
        nextPosition = new Vector3(nextSquare.transform.position.x,
                                   checkerPositionY,
                                   nextSquare.transform.position.z);
        movementTime = 0.5f;

        GameMaster.tweenManager.AddToTweens(new Tween {
            finalPosition = nextPosition,
            movementTime = movementTime,
            objectToMove = transform
        });
        CheckerHighlightOff();
        currentSquare.MarkAsFree();
        nextSquare.MarkAsOccupied(checkerColor);
        currentSquare = nextSquare;
        GameEventSystem.RiseEvent(GameEventType.ChangePlayerTurn);
    }

    public void CheckerHighlightOn()
    {
        switch (checkerColor)
        {
            case CheckerColor.White:
                mesh.material = whiteHighlighted;
                break;
            case CheckerColor.Black:
                mesh.material = blackHighlighted;
                break;
        }
    }

    public void CheckerHighlightOff()
    {
        switch (checkerColor)
        {
            case CheckerColor.White:
                mesh.material = materialWhite;
                break;
            case CheckerColor.Black:
                mesh.material = materialBlack;
                break;
        }
    }

    public void OnGameEvent(GameEventType type, object obj)
    {

    }
}

