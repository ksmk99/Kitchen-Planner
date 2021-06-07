using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public bool CanSnap { get; set; }
    public Side Side => side;
    public Position Position => position;

    [SerializeField] private Side side;
    [SerializeField] private Position position;

    private void Awake()
    {
        CanSnap = true;
    }
}

public enum Side
{
    Right,
    Left
}

public enum Position
{
    Top,
    Middle,
    Bottom
}
