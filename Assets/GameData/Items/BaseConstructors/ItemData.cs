using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item Data", menuName = "Items/Item Data")]
public class ItemData : ScriptableObject
{
    public int id;
    public ItemType itemType;
    public bool isStackable;
    public string itemName;
    public Texture image;
}
