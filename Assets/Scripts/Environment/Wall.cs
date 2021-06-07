using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool XWall => transform.localScale.x > transform.localScale.z;
    public bool ZWall => !XWall;
    public float TopLimit => transform.position.y  + transform.localScale.y / 2;
    public float BotLimit => transform.position.y - transform.localScale.y / 2;
    public float XRightLimit => transform.position.x + transform.localScale.x / 2;
    public float XLeftLimit => transform.position.x - transform.localScale.x / 2;
    public float ZRightLimit => transform.position.z + transform.localScale.z / 2;
    public float ZLeftLimit => transform.position.z - transform.localScale.z / 2;

}
