using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public class PhysicalWeapon : Item
{
    public PhysicalWeapon(int id, string name, string desc, Vector3 damage, MagicSpell[] enchants, Sprite texture)
    {
        ID = id;
        Name = name;
        itemType = item_Type.Weapon;
        Description = desc;
        Damage = damage;
        Enchants = enchants;
        Item_Image = texture;
    }

    public Vector3 Damage;
    //slash_d, crash_d, prick_d
    //Резать, пробивать, протыкать

    public MagicSpell[] Enchants = new MagicSpell[2];
    //Два нулевых зачароания при создании предмета

    public Sprite Item_Image;
}

public class Weapons : MonoBehaviour
{
    public PhysicalWeapon[] AllWeapons;

    void Start()
    {
        AllWeapons = new PhysicalWeapon[] {
        new PhysicalWeapon(0, "Sword", "Little sharp sword.", new Vector3(20, 0, 0), null, Resources.Load<Sprite>("Sword"))
        };

        transform.GetComponent<Image>().sprite = AllWeapons[0].Item_Image; //Weapons/
    }
}
