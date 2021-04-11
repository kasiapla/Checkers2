using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTurn
{
    None,
    PlayerOne,
    PlayerTwo
}

public class GameFlow: MonoBehaviour, IEventSystemUser
{
    private static PlayerTurn _playerTurn = PlayerTurn.PlayerOne;

    public static PlayerTurn PlayerTurn
    {
        get { return _playerTurn; }
    }

    void Awake()
    {
        GameEventSystem.RegisterUser(this);
    }

    public void OnGameEvent(GameEventType gameEventType, object obj)
    {
        switch (gameEventType)
        {
            case GameEventType.ChangePlayerTurn:
                ChangePlayerTurn();
                GameEventSystem.RiseEvent(GameEventType.GameFlowStatusUpdated);
                break;
        }
    }

    void ChangePlayerTurn()
    {
        switch (_playerTurn)
        {
            case PlayerTurn.PlayerOne:
                _playerTurn = PlayerTurn.PlayerTwo;
                break;
            case PlayerTurn.PlayerTwo:
                _playerTurn = PlayerTurn.PlayerOne;
                break;
            default:
                Debug.LogError("PlayerTurn == None!");
                return;
        }
    }
}
