using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CheckLimitsExtension
{
    //public static void CheckLimits(this Transform item, Environment environment, OffsetPoints offsetPoints)
    //{
    //    if(environment is XWall xWall)
    //    {
    //        CheckLimits(item, xWall, offsetPoints);
    //    }
    //    else if (environment is ZWall zWall)
    //    {
    //        CheckLimits(item, zWall, offsetPoints);
    //    }
    //    else if (environment is Floor floor)
    //    {
    //        CheckLimits(item, floor, offsetPoints);
    //    }
    //}

    //private static void CheckLimits(Transform item, XWall wall, OffsetPoints offsetPoints)
    //{
    //    var xPos = item.position.x;
    //    var yPos = item.position.y;
    //    var zPos = item.position.z;

    //    var floorOffset = Mathf.Abs(offsetPoints.FloorOffset);
    //    if (yPos < wall.BotLimit + floorOffset)
    //    {
    //        yPos = wall.BotLimit + floorOffset;
    //    }
    //    else if (yPos > wall.TopLimit - floorOffset)
    //    {
    //        yPos = wall.TopLimit - floorOffset;
    //    }

    //    if (wall.XWall)
    //    {
    //        if (xPos > wall.XRightLimit - Mathf.Abs(offsetPoints.RightOffset))
    //        {
    //            xPos = wall.XRightLimit - Mathf.Abs(offsetPoints.RightOffset);
    //        }
    //        else if (xPos < wall.XLeftLimit + Mathf.Abs(offsetPoints.LeftOffset))
    //        {
    //            xPos = wall.XLeftLimit + Mathf.Abs(offsetPoints.LeftOffset);
    //        }
    //    }
    //    else
    //    {
    //        if (zPos > wall.ZRightLimit - Mathf.Abs(offsetPoints.RightOffset))
    //        {
    //            zPos = wall.ZRightLimit - Mathf.Abs(offsetPoints.RightOffset);
    //        }
    //        else if (zPos < wall.ZLeftLimit + Mathf.Abs(offsetPoints.LeftOffset))
    //        {
    //            zPos = wall.ZLeftLimit + Mathf.Abs(offsetPoints.LeftOffset);
    //        }
    //    }

    //    item.position = new Vector3(xPos, yPos, zPos);
    //}

    //private static void CheckLimits(this Transform item, Floor floor, OffsetPoints offsetPoints)
    //{
    //    var xPos = item.position.x;
    //    var yPos = item.position.y;
    //    var zPos = item.position.z;


    //    if (xPos > floor.RightLimit - Mathf.Abs(offsetPoints.RightOffset))
    //    {
    //        xPos = floor.RightLimit - Mathf.Abs(offsetPoints.RightOffset);
    //    }
    //    else if (xPos < floor.LeftLimit + Mathf.Abs(offsetPoints.LeftOffset))
    //    {
    //        xPos = floor.LeftLimit + Mathf.Abs(offsetPoints.LeftOffset);
    //    }

    //    var offset = Mathf.Abs(offsetPoints.WallOffset);
    //    if (zPos > floor.TopLimit - offset)
    //    {
    //        zPos = floor.TopLimit - offset;
    //    }
    //    else if (zPos < floor.BotLimit + offset)
    //    {
    //        zPos = floor.BotLimit + offset;
    //    }

    //    item.position = new Vector3(xPos, yPos, zPos);
    //}

    //private static bool IsInLimits(this Transform item, Wall wall, OffsetPoints offsetPoints)
    //{
    //    var xPos = item.position.x;
    //    var yPos = item.position.y;
    //    var zPos = item.position.z;

    //    var floorOffset = Mathf.Abs(offsetPoints.FloorOffset);
    //    if (yPos < wall.BotLimit + floorOffset) return false;
    //    else if (yPos > wall.TopLimit - floorOffset) return false;

    //    if (wall.XWall)
    //    {
    //        if (xPos > wall.XRightLimit - Mathf.Abs(offsetPoints.RightOffset)) return false;
    //        else if (xPos < wall.XLeftLimit + Mathf.Abs(offsetPoints.LeftOffset)) return false;
    //    }
    //    else
    //    {
    //        if (zPos > wall.ZRightLimit - Mathf.Abs(offsetPoints.RightOffset)) return false;
    //        else if (zPos < wall.ZLeftLimit + Mathf.Abs(offsetPoints.LeftOffset)) return false;
    //    }

    //    return true;
    //}

    //private static bool IsInLimits(this Transform item, Floor floor, OffsetPoints offsetPoints)
    //{
    //    var xPos = item.position.x;
    //    var yPos = item.position.y;
    //    var zPos = item.position.z;


    //    if (xPos > floor.RightLimit - Mathf.Abs(offsetPoints.RightOffset)) return false;
    //    else if (xPos < floor.LeftLimit + Mathf.Abs(offsetPoints.LeftOffset)) return false;
    //    var offset = Mathf.Abs(offsetPoints.WallOffset);
    //    if (zPos > floor.TopLimit - offset) return false;
    //    else if (zPos < floor.BotLimit + offset) return false;

    //    return true;
    //}
}
