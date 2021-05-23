using UnityEngine;

public class HumanPlayerController : MonoBehaviour
{
    [SerializeField] LayerMask _layerSquares;
    [SerializeField] LayerMask _layerCheckers;
    Square clickedSquare;
    Checker clickedChecker;

    void Update()
    {
        ClickChecker();
        ClickSquare();
    }

    public void ClickSquare()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, _layerSquares))
            {
                if (hit.transform.gameObject.tag == "ClickableSquare")
                {
                    clickedSquare = hit.collider?.GetComponent<Square>();
                    if (clickedSquare.IsHighlighted) clickedChecker.MoveChecker(clickedSquare);
                    else GameEventSystem.RiseEvent(GameEventType.ClearHighlight);
                }

                if (hit.transform.gameObject.tag == "WhiteSquare")
                {
                   GameEventSystem.RiseEvent(GameEventType.ClearHighlight);
                }
            }
        }
    }

    void ClickChecker()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, _layerCheckers))
            {
                if (hit.transform.gameObject.tag == "Checker")
                {
                    clickedChecker = hit.collider?.GetComponent<Checker>();
                    GameEventSystem.RiseEvent(GameEventType.DisplayPossibleMoves, clickedChecker.CurrentSquare);
                }
            }
        }
    }
}


//dodac statyczna metode ktora przyjmuje true/false i włącza/wyłącza ten skrypt