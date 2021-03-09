using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayerController : MonoBehaviour
{
    // public GameObject particle;
    private Checker[] checker;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            /*if (Physics.Raycast(ray,out RaycastHit hitInfo))
                Instantiate(particle, hitInfo.point, transform.rotation);*/
        }
    }
}
