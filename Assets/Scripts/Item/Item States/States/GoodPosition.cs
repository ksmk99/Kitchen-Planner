using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPosition : ItemState
{
    private Material material;

    public GoodPosition()
    {
        material = Resources.Load<Material>("Materials/Good Material");
    }

    public override void ChangeColor(MeshRenderer[] meshRenderers)
    {
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.materials = new Material[1] { material };
        }
    }
}