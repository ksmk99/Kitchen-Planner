using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsContainer : MonoBehaviour
{
    public static ItemsContainer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void RefreshContainer()
    {
        var items = GetComponentsInChildren<Item>();
        foreach (var item in items)
        {
            Destroy(item.gameObject);
        }
    }
}
