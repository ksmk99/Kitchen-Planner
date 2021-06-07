using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Installed : ItemState
{ 
    public override void ChangeColor(MeshRenderer[] meshRenderers)
    {
        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].materials = colorChanger.DefaultMaterials[i];
        }
    }
}
