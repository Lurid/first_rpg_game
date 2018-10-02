using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum spell_Type { Damage, Damage_Absorb, Heal };

public class MagicSpell : Item
{
    public MagicSpell(int id, string name, string desc, spell_Type spellType, Vector3 damage)
    {
        ID = id;
        Name = name;
        itemType = item_Type.Spell;
        Description = desc;
        SpellType = spellType;
        Damage = damage;
    }

    public Vector3 Damage = Vector3.zero;
    //fire_d, ice_d, electric_d
    //Огонь, лёд, электричество

    public spell_Type SpellType = spell_Type.Damage;
    //Тип заклинания
}



    //[Range(0f, 100f)] public Vector3 Absorb = Vector3.zero;
    //absorb effect (from 0% to 100%)

public class Spells : MonoBehaviour
{
    public MagicSpell[] ElderSpells = new MagicSpell[] {
        new MagicSpell(0, "Fireball", "Flying light fireball.",(spell_Type)(0),  new Vector3(20, 0, 0))
    };
}
