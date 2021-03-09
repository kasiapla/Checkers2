using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerTurn
{
    None,
    PlayerOne,
    PlayerTwo
}

public class CameraController : MonoBehaviour
{
    protected PlayerTurn playerIndex = PlayerTurn.None;

    private void Start()
    {
        playerIndex = PlayerTurn.PlayerOne;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            switch (playerIndex)
            {
                case PlayerTurn.PlayerOne:
                    playerIndex = PlayerTurn.PlayerTwo;
                    break;
                case PlayerTurn.PlayerTwo:
                    playerIndex = PlayerTurn.PlayerOne;
                    break;
                default:
                    Debug.LogError("PlayerTurn == None!");
                    return;
            }
            GetComponent<Animator>().SetInteger("ChangeToPlayer", (int)playerIndex);
        }
    }
}
