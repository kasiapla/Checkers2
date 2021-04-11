using UnityEngine;

public class HumanPlayerController : MonoBehaviour
{
    [SerializeField] LayerMask _layerSquares;

    void Update()
    {
        ClickSquare();
        EndTurn();
    }

    public void ClickSquare()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameEventSystem.RiseEvent(GameEventType.ClearHighlight);
                if (hit.transform.gameObject.layer == _layerSquares)
                {
                    GameEventSystem.RiseEvent(GameEventType.DisplayPossibleMoves, hit.collider?.GetComponent<Square>());
                }
            }
        }
    }

    public void EndTurn()
    {
        if (Input.GetKeyDown(KeyCode.Space)) GameEventSystem.RiseEvent(GameEventType.ChangePlayerTurn);
    }
}


