using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EquipType
{
    Hat,
    Chest,
    Legs,
    Boots,
    Ring,
    M_Weapon,
    R_Weapon
}
public class PlayerEquipmentObject : ScriptableObject
{
    public Dictionary<EquipType, EquipObject> gear = new Dictionary<EquipType, EquipObject>();

    public void equip(EquipObject item)
    {
        if (gear.ContainsKey(item.equiptype))
            gear[item.equiptype] = item;
        else
            gear.Add(item.equiptype, item);
    }

    public void unequip(EquipObject item)
    {
        gear.Remove(item.equiptype);
    }
}
