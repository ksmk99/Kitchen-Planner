using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZWall : MonoBehaviour, Environment
{
    [SerializeField] private float magnetValue = 0.5f;

    public Vector3 CnahgeVector => new Vector3(0, 1, 1);
    public float TopLimit => transform.position.y + transform.localScale.y / 2;
    public float BotLimit => transform.position.y - transform.localScale.y / 2;
    public float RightLimit => transform.position.z + transform.localScale.x / 2;
    public float LeftLimit => transform.position.z - transform.localScale.x / 2;

    public void CheckLimits(Transform item, OffsetPoints offsetPoints)
    {
        var xPos = item.position.x;
        var yPos = item.position.y;
        var zPos = item.position.z;

        if (yPos < BotLimit + Mathf.Abs(offsetPoints.FloorBotOffset) + magnetValue)
        {
            yPos = BotLimit + Mathf.Abs(offsetPoints.FloorBotOffset);
        }
        else if (yPos > TopLimit - Mathf.Abs(offsetPoints.FloorTopOffset))
        {
            yPos = TopLimit - Mathf.Abs(offsetPoints.FloorTopOffset);
        }

        if (zPos > RightLimit - Mathf.Abs(offsetPoints.LeftOffset))
        {
            zPos = RightLimit - Mathf.Abs(offsetPoints.LeftOffset);
        }
        else if (zPos < LeftLimit + Mathf.Abs(offsetPoints.RightOffset))
        {
            zPos = LeftLimit + Mathf.Abs(offsetPoints.RightOffset);
        }

        item.position = new Vector3(xPos, yPos, zPos);
    }

    public bool IsGrounded(Transform item, OffsetPoints offsetPoints)
    {
        Debug.Log(Mathf.Abs(item.position.y - BotLimit - Mathf.Abs(offsetPoints.FloorBotOffset)));
        return Mathf.Abs(item.position.y - BotLimit - Mathf.Abs(offsetPoints.FloorBotOffset)) < magnetValue;
    }

    public bool IsInLimits(Transform item, OffsetPoints offsetPoints)
    {
        var yPos = item.position.y;
        var zPos = item.position.z;

        var floorOffset = Mathf.Abs(offsetPoints.FloorBotOffset);
        if (yPos < BotLimit + floorOffset) return false;
        else if (yPos > TopLimit - floorOffset) return false;

        if (zPos > RightLimit - Mathf.Abs(offsetPoints.RightOffset)) return false;
        else if (zPos < LeftLimit + Mathf.Abs(offsetPoints.LeftOffset)) return false;

        return true;
    }
}
