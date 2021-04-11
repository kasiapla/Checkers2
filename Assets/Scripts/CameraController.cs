using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour, IEventSystemUser
{
    void Awake()
    {
        GameEventSystem.RegisterUser(this);
    }

    void ChangeCameraPosition()
    {
        GetComponent<Animator>()?.SetInteger("ChangeToPlayer", (int)GameFlow.PlayerTurn);
    }

    public void OnGameEvent(GameEventType gameEventType, object parameter)
    {
        switch (gameEventType)
        {
            case GameEventType.GameFlowStatusUpdated:
                ChangeCameraPosition();
                break;
        }
    }
}
