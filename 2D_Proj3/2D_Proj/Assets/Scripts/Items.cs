using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum item_Type { Weapon, Armor, Key, Book, Spell, Perk, Other_Item, Other }
public enum armor_Type { Head, Body, left_Hand, right_Hand, left_Foot, right_Foot };

public class Item
{
    public int ID;
    public string Name;
    public string Description;
    public item_Type itemType;
}

public class Armor : Item
{
    public Armor(int id, string name, armor_Type ty, Vector3 m_r, Vector3 p_r)
    {
        ID = id;
        Name = name;
        itemType = item_Type.Armor;
        Magic_Resist = m_r;
        Physical_Resist = p_r;
        ArmorType = ty;
    }

    public Armor(armor_Type ty)
    {
        ArmorType = ty;
    }

    [Range(0f, 100f)] public float condition = 100;
    
    public armor_Type ArmorType;

    public Vector3 Magic_Resist = Vector3.zero;
    //fire_r, ice_r, electric_r

    public Vector3 Physical_Resist = Vector3.zero;
    //slash_r, crash_r, prick_r

    [Range(0f, 100f)] public float dodge_chanse = 0;
}

public class Items : MonoBehaviour {

    /*public class Armor : Item
    {
        public armor_Type Armor_Type;
        [Range(0f, 100f)] public float condition = 100;

        public Vector3 Magic_Resist = Vector3.zero;
        //fire_r, ice_r, electric_r

        public Vector3 Physical_Resist = Vector3.zero;
        //slash_r, crash_r, prick_r

        [Range(-100f, 100f)] public float dodge_chanse = 0;
        public MagicSpell first_Spell;
        public MagicSpell second_Spell;
    }*/

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
