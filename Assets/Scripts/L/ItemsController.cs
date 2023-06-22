using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    private List<IUsable> usableItems;

    private void Start()
    {
        SetUsableItems();
        GetItemsDescription();
        UseItems();
    }

    private void SetUsableItems()
    {
        usableItems = new List<IUsable>();

        foreach (var item in items)
        {
            if (item is IUsable)
            {
                usableItems.Add(item as IUsable);
            }
        }
    }

    private void GetItemsDescription()
    {
        foreach (var item in items)
        {
            item.GetDescription();
        }
    }

    private void UseItems()
    {
        foreach (var item in usableItems)
        {
            item.Use();
        }
    }
}
