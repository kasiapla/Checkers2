using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SquareOccupation
{
    Free,
    WhiteCheckerOn,
    BlackCheckerOn
}

public enum SquareStatus
{
    None,
    WhitePromotion,
    BlackPromotion
}

public class Square : MonoBehaviour
{
    [SerializeField] public SquareOccupation occupation { get; }
    [SerializeField] public SquareStatus status { get; }
    [SerializeField] public Square[] upperSquares { get; }
    [SerializeField] public Square[] lowerSquares { get; }
    [SerializeField] private Material material1;
    [SerializeField] private Material material2;
    [SerializeField] private Material material3;
    [SerializeField] private MeshRenderer mesh;

    public void ChangeSquareColor()
    {
        if (mesh.material.name.Contains(material1.name)) mesh.material = material2;
        else mesh.material = material1;
    }

    public void ChangeSquareColor2()
    {
        if (mesh.material.name.Contains(material1.name)) mesh.material = material3;
        else mesh.material = material1;
    }
}

