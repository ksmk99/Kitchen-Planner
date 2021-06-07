using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ItemState
{
    protected ColorChanger colorChanger;

    public void SetContext(ColorChanger colorChanger)
    {
        this.colorChanger = colorChanger;
    }

    public abstract void ChangeColor(MeshRenderer[] meshRenderers);
}
