using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="ItemButtonData")]
public class ItemButtonData : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public GameObject Item;
}
