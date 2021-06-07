using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDown : MonoBehaviour, IPointerDownHandler
{
    private ShopItem shopItem;
    private ScrollRect scrollRect;

    private void Start()
    {
        shopItem = GetComponent<ShopItem>();
        scrollRect = GetComponentInParent<ScrollRect>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        scrollRect.enabled = false;
        shopItem.CreateItem();
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        yield return new WaitForFixedUpdate();
        scrollRect.enabled = true;
    }
}
