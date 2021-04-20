using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameEventType
{
    DisplayPossibleMoves,
    ClearHighlight,
    ChangePlayerTurn,
    GameFlowStatusUpdated,
    MoveChecker,
    UpdateSquareStatus,
}
public interface IEventSystemUser {
    void OnGameEvent(GameEventType type, object parameter);
}

public static class GameEventSystem
{
    static List<IEventSystemUser> users = new List<IEventSystemUser>();

    public static void RegisterUser(IEventSystemUser newUser)
    {
        users.Add(newUser);
    }

    public static void RiseEvent(GameEventType type, object parameter = null)
    {
        for (int i = 0; i < users.Count; i++)
        {
            users[i].OnGameEvent(type, parameter);
        }
    }
}
