using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPoints : MonoBehaviour
{
    public float WallBackOffset => wallBackTransform.localPosition.z;
    public float WallForwardOffset => wallForwardTransform.localPosition.z;
    public float FloorBotOffset => floorBotTransform.localPosition.y;
    public float FloorTopOffset => floorTopTransform.localPosition.y;

    public float LeftOffset => leftTransform.localPosition.x;
    public float RightOffset => rightTransform.localPosition.x;


    [SerializeField] private Transform wallBackTransform;
    [SerializeField] private Transform wallForwardTransform;
    [SerializeField] private Transform floorBotTransform;
    [SerializeField] private Transform floorTopTransform;

    [SerializeField] private Transform leftTransform;
    [SerializeField] private Transform rightTransform;
}
