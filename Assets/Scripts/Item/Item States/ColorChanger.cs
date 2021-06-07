using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public List<Material[]> DefaultMaterials;

    private ItemState itemState = null;
    private MeshRenderer[] meshRenderers;

    private void Awake()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        DefaultMaterials = meshRenderers.Select(x => x.materials).ToList();
        //TransitionTo(new GoodPosition());
    }

    public void TransitionTo(ItemState itemState)
    {
        this.itemState = itemState;
        this.itemState.SetContext(this);
        this.itemState.ChangeColor(meshRenderers);
    }
}
