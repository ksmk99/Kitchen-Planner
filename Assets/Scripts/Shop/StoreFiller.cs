using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreFiller : MonoBehaviour
{
    [SerializeField]
    private GameObject shopButtonPrefab;

    private void Awake()
    {
        var itemsData = Resources.LoadAll<ItemButtonData>("Gui Buttons");
        foreach (var itemData in itemsData)
        {
            var button = Instantiate(shopButtonPrefab);
            button.transform.parent = transform;

            button.GetComponent<ShopItem>().FillShopItem(itemData);
        }
    }
}
