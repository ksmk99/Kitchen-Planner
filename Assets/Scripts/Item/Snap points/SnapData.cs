using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapData
{
    public readonly SnapPoint[] Points;
    public readonly Vector3 Offset;

    public SnapData(SnapPoint[] points, Vector3 offset)
    {
        Points = points;
        Offset = offset;
    }

    public SnapData()
    {
        Points = new SnapPoint[0];
        Offset = new Vector3();
    }
}
