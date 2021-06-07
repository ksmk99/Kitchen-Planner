using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;
    [SerializeField] private Text itemName;

    private GameObject item;

    public void FillShopItem(ItemButtonData data)
    {
        itemImage.sprite = data.Image;
        itemName.text = data.Name;
        item = data.Item;
    }

    public void CreateItem()
    {
        var item = Instantiate(this.item);
        item.transform.parent = ItemsContainer.Instance.transform;
    }
}
