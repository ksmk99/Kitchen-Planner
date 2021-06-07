using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Environment
{
    public Vector3 CnahgeVector { get; }
    public float TopLimit { get; }
    public float BotLimit { get; }
    public float RightLimit { get; }
    public float LeftLimit { get; }

    public void CheckLimits(Transform item, OffsetPoints offsetPoints);

    public bool IsInLimits(Transform item, OffsetPoints offsetPoints);

    public bool IsGrounded(Transform item, OffsetPoints offsetPoints);
}
