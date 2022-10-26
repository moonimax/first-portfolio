using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public MeshRenderer mesh;
    public GameObject gameobject;
    public Vector3 offset;

    public int armorModifier;
    public int damageModifier;

    public int itemvalue;

    public override void Use()
    {
        base.Use();
        EquipmentManager.Instance.Equip(this);
        //Equip the item
        //Remove it from the inventory
        RemoveFromInventory();
    }

}

public enum EquipmentSlot { Weapon}

