using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InventoryHandler : MonoBehaviour
{
    public int size;
    public int rows;
    public InventoryItem selectedItem;
    public Ui ui;
    public List<InventoryItem> items = new List<InventoryItem>();
    public List<InventoryAction> inventoryChanges = new List<InventoryAction>();

    void OnTriggerEnter(Collider other)
    {
        Item item = other.gameObject.GetComponent<Item>();
        if (item != null)
        {
            AddItem(item);
        }
    }

    void AddItem(Item newItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item.itemData.id == newItem.itemData.id && items[i].item.itemData.isStackable)
            {
                items[i].count += newItem.count;
                inventoryChanges.Add(new InventoryAction(i, ItemAction.Add, newItem.count, items[i]));
                Destroy(newItem.gameObject);
                return;
            }
        }
        if (items.Count < size)
        {
            items.Add(new InventoryItem(newItem, newItem.count, items.Count, false));
            inventoryChanges.Add(new InventoryAction(items.Count - 1, ItemAction.Add, newItem.count, items[items.Count - 1]));
            newItem.count = 1;
            newItem.gameObject.SetActive(false);
        }
    }

    public void DropItem(int index, bool dropAll, bool isEquipped)
    {
        if (isEquipped || items[index].count == 1 || dropAll)
        {
            InventoryItem inventoryItem;
            if (isEquipped)
            {
                inventoryItem = selectedItem;
            }
            else
            {
                inventoryItem = items[index];
            }

            Transform itemTransform = inventoryItem.item.gameObject.transform;
            inventoryItem.item.gameObject.SetActive(true);
            itemTransform.position = new Vector3(transform.position.x + (transform.forward.x * 2), 1, transform.position.z + (transform.forward.z * 2));
            inventoryItem.item.count = inventoryItem.count;
            if (!isEquipped)
            {
                items.RemoveAt(index);
            }
            else
            {
                selectedItem = null;
            }

        }
        else
        {
            items[index].count -= 1;
            Instantiate(items[index].item.gameObject, new Vector3(transform.position.x + (transform.forward.x * 2),
            1, transform.position.z + (transform.forward.z * 2)), Quaternion.identity).SetActive(true);
        }
    }
}

public struct InventoryAction
{
    public ItemAction action;
    public int inventorySlot;
    public int amount;
    public InventoryItem item;
    public InventoryAction(int inventorySlot, ItemAction action, int amount, InventoryItem item)
    {
        this.action = action;
        this.amount = amount;
        this.inventorySlot = inventorySlot;
        this.item = item;
    }
}

public enum ItemAction
{
    Add,
    Remove
}

public class InventoryItem
{
    public int count;
    public Item item;
    public int index;
    public bool isEquipped;
    public InventoryItem(Item item, int count, int index, bool isEquipped)
    {
        this.count = count;
        this.item = item;
        this.index = index;
        this.isEquipped = isEquipped;
    }
}