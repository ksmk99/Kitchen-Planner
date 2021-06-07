using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWall : MonoBehaviour, Environment
{
    [SerializeField] private float magnetValue = 0.5f;

    public Vector3 CnahgeVector => new Vector3(1, 1, 0);

    public float TopLimit => transform.position.y + transform.localScale.y / 2;
    public float BotLimit => transform.position.y - transform.localScale.y / 2;
    public float RightLimit => transform.position.x + transform.localScale.x / 2;
    public float LeftLimit => transform.position.x - transform.localScale.x / 2;

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

        if (xPos > RightLimit - Mathf.Abs(offsetPoints.RightOffset))
        {
            xPos = RightLimit - Mathf.Abs(offsetPoints.RightOffset);
        }
        else if (xPos < LeftLimit + Mathf.Abs(offsetPoints.LeftOffset))
        {
            xPos = LeftLimit + Mathf.Abs(offsetPoints.LeftOffset);
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
        var xPos = item.position.x;
        var yPos = item.position.y;

        if (yPos < BotLimit + Mathf.Abs(offsetPoints.FloorBotOffset))
            return false;
        else if (yPos > TopLimit - Mathf.Abs(offsetPoints.FloorTopOffset))
            return false;

        if (xPos > RightLimit - Mathf.Abs(offsetPoints.RightOffset))
            return false;
        else if (xPos < LeftLimit + Mathf.Abs(offsetPoints.LeftOffset))
            return false;

        return true;
    }
}
