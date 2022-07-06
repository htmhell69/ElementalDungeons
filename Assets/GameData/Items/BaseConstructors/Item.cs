using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData itemData;
    public int count;
    public bool owned;
    public InventoryHandler owner;
    public int index;

    public virtual void OnUse()
    {

    }
}


public enum ItemType
{
    None,
    Weapon,
    Consumable,
    Currency,
    SpellBook,
    Simple
}