using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnapPoints : MonoBehaviour
{
    [SerializeField] private LayerMask layer;
    [SerializeField] [Range(0.1f, 1f)]
    private float snapDistance = 0.5f;

    private List<SnapPoint> rightSnapPoints;
    private List<SnapPoint> leftSnapPoints;
    private List<SnapPoint> snapPoints;

    private SnapData snapData = new SnapData();

    private float sphereRadius = 1f;

    private void Awake()
    {
        SetSnapPoints();
    }

    public Vector3 GetSnapOffset()
    {
        snapPoints = Physics.OverlapSphere(transform.position, sphereRadius, layer.value)
            .Select(x => x.GetComponent<SnapPoint>())
            .Where(x => x != null && x.CanSnap &&
            !rightSnapPoints.Contains(x) && !leftSnapPoints.Contains(x))
            .ToList();

        if (snapPoints.Count == 0) return new Vector3();

        var closestSnapPoint = FindClosestPoint(transform.position, snapPoints);
        var isGrounded = closestSnapPoint.GetComponentInParent<Item>().IsGrounded;

        var currentSnapPoints = closestSnapPoint.Side == Side.Right ? leftSnapPoints : rightSnapPoints;
        var closestSnapPoints = FindMinDistance(currentSnapPoints, snapPoints, isGrounded);

        if (closestSnapPoints == null) return new Vector3();

        var offset = closestSnapPoints.Item2 - closestSnapPoints.Item1;
        return offset.magnitude > snapDistance ? new Vector3() : offset;
    }

    private Tuple<Vector3, Vector3> FindMinDistance(List<SnapPoint> points, List<SnapPoint> snapPoints, bool isGrounded)
    {
        var minDistance = float.MaxValue;
        Tuple<Vector3, Vector3> result = null;

        if(isGrounded)
        {
            points = points.Where(x => x.Position == Position.Bottom).ToList();
            snapPoints = snapPoints.Where(x => x.Position == Position.Bottom).ToList();
        }

        foreach (var point in points)
        {
            foreach (var snapPoint in snapPoints)
            {
                if (point.Position == snapPoint.Position && point.Side != snapPoint.Side)
                {
                    var distance = Vector3.Distance
                        (point.transform.position, snapPoint.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        result = new Tuple<Vector3, Vector3>
                            (point.transform.position, snapPoint.transform.position);
                    }
                }
            }
        }
        return result;
    }

    private SnapPoint FindClosestPoint(Vector3 position, List<SnapPoint> points)
    {
        var minDistance = float.MaxValue;
        var closest = points[0];
        foreach (var point in points)
        {
            var dictance = Vector3.Distance(position, point.transform.position);
            if (dictance < minDistance)
            {
                closest = point;
                minDistance = dictance;
            }
        }
        return closest;
    }

    private void SetSnapPoints()
    {
        var snapPoints = GetComponentsInChildren<SnapPoint>();
        rightSnapPoints = new List<SnapPoint>();
        leftSnapPoints = new List<SnapPoint>();

        foreach (var snapPoint in snapPoints)
        {
            if (snapPoint.Side == Side.Left) leftSnapPoints.Add(snapPoint);
            else rightSnapPoints.Add(snapPoint);

        }
    }

}
