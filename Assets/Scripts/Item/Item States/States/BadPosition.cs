using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPosition : ItemState
{
    private Material material;

    public BadPosition()
    {
        material = Resources.Load<Material>("Materials/Bad Material");
    }

    public override void ChangeColor(MeshRenderer[] meshRenderers)
    {
        foreach (var meshRenderer in meshRenderers)
        {
            meshRenderer.materials = new Material[1] { material };
        }
    }
}
