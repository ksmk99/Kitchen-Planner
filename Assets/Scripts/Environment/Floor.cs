using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour, Environment
{
    [SerializeField] private float magnetValue = 0.5f;
    public float TopLimit => transform.position.z + transform.localScale.z / 2;
    public float BotLimit => transform.position.z - transform.localScale.z / 2;
    public float RightLimit => transform.position.x + transform.localScale.x / 2;
    public float LeftLimit => transform.position.x - transform.localScale.x / 2;

    public Vector3 CnahgeVector => new Vector3(1, 0, 1);

    public void CheckLimits(Transform item, OffsetPoints offsetPoints)
    {
        var xPos = item.position.x;
        var yPos = item.position.y;
        var zPos = item.position.z;


        if (xPos > RightLimit - Mathf.Abs(offsetPoints.RightOffset) - magnetValue)
            xPos = RightLimit - Mathf.Abs(offsetPoints.RightOffset);
        else if (xPos < LeftLimit + Mathf.Abs(offsetPoints.LeftOffset))
            xPos = LeftLimit + Mathf.Abs(offsetPoints.LeftOffset);

        if (zPos > TopLimit - Mathf.Abs(offsetPoints.WallBackOffset) - magnetValue)
            zPos = TopLimit - Mathf.Abs(offsetPoints.WallBackOffset);
        else if (zPos < BotLimit + Mathf.Abs(offsetPoints.WallForwardOffset))
            zPos = BotLimit + Mathf.Abs(offsetPoints.WallForwardOffset);

        item.position = new Vector3(xPos, yPos, zPos);
    }

    public bool IsGrounded(Transform item, OffsetPoints offsetPoints)
    {
        return true;
    }

    public bool IsInLimits(Transform item, OffsetPoints offsetPoints)
    {
        var xPos = item.position.x;
        var yPos = item.position.y;
        var zPos = item.position.z;


        if (xPos > RightLimit - Mathf.Abs(offsetPoints.RightOffset)) return false;
        else if (xPos < LeftLimit + Mathf.Abs(offsetPoints.LeftOffset)) return false;
        if (zPos > TopLimit - Mathf.Abs(offsetPoints.WallBackOffset)) return false;
        else if (zPos < BotLimit + Mathf.Abs(offsetPoints.WallForwardOffset)) return false;

        return true;
    }
}
