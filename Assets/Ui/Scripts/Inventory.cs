using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Inventory : MonoBehaviour
{
    public InventoryHandler inventory;
    public GameObject itemContainer;
    public GameObject uiItemPrefab;
    bool hasSlots = false;
    int currentItemCount = 0;
    void Start()
    {
        transform.GetChild(0).gameObject.GetComponent<GridLayoutGroup>().constraintCount = inventory.rows;
        //creating base ui for inventory
        for (int i = 0; i < inventory.size; i++)
        {
            CreateItemContainer();
        }
        hasSlots = true;
        if (inventory.inventoryChanges.Count > 0)
        {
            while (0 < inventory.inventoryChanges.Count)
            {
                Debug.Log(inventory.inventoryChanges[0].item.item.itemData.id);
                UpdateInventory(inventory.inventoryChanges[0]);
                inventory.inventoryChanges.RemoveAt(0);
            }

        }
    }
    void OnEnable()
    {
        if (hasSlots)
        {
            if (inventory.inventoryChanges.Count > 0)
            {
                while (0 < inventory.inventoryChanges.Count)
                {
                    UpdateInventory(inventory.inventoryChanges[0]);
                    inventory.inventoryChanges.RemoveAt(0);
                }

            }
        }
    }


    void CreateItemContainer()
    {
        GameObject container = Instantiate(itemContainer);
        container.transform.SetParent(transform.GetChild(0));
    }

    void UpdateInventory(InventoryAction action)
    {
        if (action.action == ItemAction.Add)
        {
            AddItem(action.item, action.inventorySlot);
        }
    }

    void AddItem(InventoryItem inventoryItem, int index)
    {
        if (index == currentItemCount)
        {
            Transform container = GetItemContainer(index);
            GameObject uiItem = Instantiate(uiItemPrefab, Vector3.zero, Quaternion.identity);
            RawImage uiItemImage = uiItem.GetComponent<RawImage>();
            TMP_Text text = uiItem.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            uiItemImage.texture = inventoryItem.item.itemData.image;
            text.text = inventoryItem.count.ToString();
            uiItem.transform.GetChild(1).GetChild(1).GetComponent<Button>().onClick.AddListener(delegate { DropItem(inventoryItem, inventoryItem.index, false); });
            uiItem.transform.GetChild(1).GetChild(2).GetComponent<Button>().onClick.AddListener(delegate { DropItem(inventoryItem, inventoryItem.index, true); });
            uiItem.transform.GetChild(1).GetChild(0).GetComponent<Button>().onClick.AddListener(delegate { EquipItem(inventoryItem, inventoryItem.index); });
            uiItem.transform.SetParent(container, false);
            currentItemCount += 1;
        }
        else
        {

            GameObject uiItem = GetItemContainer(index).GetChild(0).gameObject;
            TMP_Text text = uiItem.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            text.text = inventoryItem.count.ToString();
        }
    }



    void DropItem(InventoryItem inventoryItem, int index, bool dropAll)
    {
        if (inventoryItem.isEquipped || inventoryItem.count == 1 || dropAll)
        {
            if (!inventoryItem.isEquipped)
            {
                ReadjustAfterRemoval(index);
                currentItemCount -= 1;
                Destroy(GetItemContainer(index).GetChild(0).gameObject);
            }
            else
            {
                Destroy(transform.GetChild(1).GetChild(0).gameObject);
            }
        }
        else
        {
            GetItemContainer(index).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = (inventoryItem.count - 1).ToString();
        }

        inventory.DropItem(index, dropAll, inventoryItem.isEquipped);
    }

    void ReadjustAfterRemoval(int index)
    {
        for (int i = index + 1; i < inventory.items.Count; i++)
        {
            inventory.items[i].index -= 1;
            Transform item = GetItemContainer(i).GetChild(0);
            item.SetParent(GetItemContainer(i - 1), false);
        }
    }

    void EquipItem(InventoryItem item, int index)
    {
        item.isEquipped = true;
        GetItemContainer(index).GetChild(0).SetParent(transform.GetChild(1), false);
        inventory.selectedItem = item;
        ReadjustAfterRemoval(index);
        inventory.items.RemoveAt(index);
        currentItemCount -= 1;
    }

    Transform GetItemContainer(int index)
    {
        return transform.GetChild(0).GetChild(index);
    }


}
