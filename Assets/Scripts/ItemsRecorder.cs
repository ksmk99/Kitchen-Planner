using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRecorder : MonoBehaviour
{
    [SerializeField] private GameObject[] items;

    private int index;
    private void Start()
    {
        StartCoroutine(ObjectSwitcher());
    }

    private IEnumerator ObjectSwitcher()
    {
        Debug.Log(items[index].name);
        items[index].SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        items[index].SetActive(false);
        index++;
        if(index < items.Length)
            StartCoroutine(ObjectSwitcher());
    }
}
