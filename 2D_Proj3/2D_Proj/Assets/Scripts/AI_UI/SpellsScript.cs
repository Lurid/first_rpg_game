using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum ItemType
{
    Spell, Weapon, Clothes
}

public class Item
{
    public int ID;
    public string Name;
    public string Description;
    public ItemType itemType;
}

public class MagicSpell : Item
{
    public MagicSpell(int id, string name, string desc, Vector3 damage, Vector3 absorb)
    {
        ID = id;
        Name = name;
        itemType = ItemType.Spell;
        Description = desc;
        Damage = damage;
        Absorb = absorb;
    }
    
    public Vector3 Damage = Vector3.zero;
    //fire_d, ice_d, electric_d
    //Огонь, лёд, электричество

    [Range(0f, 100f)] public Vector3 Absorb = Vector3.zero;
    //absorb effect (from 0% to 100%)
}

public class PhysicalWeapon : Item
{
    public PhysicalWeapon(int id, string name, string desc, Vector3 damage, MagicSpell[] enchants)
    {
        ID = id;
        Name = name;
        itemType = ItemType.Weapon;
        Description = desc;
        Damage = damage;
        Enchants = enchants;
    }

    public Vector3 Damage;
    //slash_d, crash_d, prick_d
    //Резать, пробивать, протыкать

    public MagicSpell[] Enchants = new MagicSpell[2];
    //Два нулевых зачароания при создании предмета
}

public class SpellsScript : MonoBehaviour
{
    public MagicSpell[] ElderSpells = new MagicSpell[] {
        new MagicSpell(0, "Fireball", "Flying light fireball.", new Vector3(20, 0, 0), Vector3.zero)
    };
    public PhysicalWeapon[] AllWeapons = new PhysicalWeapon[] {
        new PhysicalWeapon(0, "Sword", "Little sharp sword.", new Vector3(20, 0, 0), null)
    };
}
