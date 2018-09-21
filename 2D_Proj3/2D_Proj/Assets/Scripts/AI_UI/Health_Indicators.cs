using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cloth_type
{
    Head, Body, Leg, Foot
}

public class Clothes : Item
{


    public Clothes(int id, string name, cloth_type ty, Vector3 m_r, Vector3 p_r)
    {
        ID = id;
        Name = name;
        itemType = ItemType.Clothes;
        Magic_Resist = m_r;
        Physical_Resist = p_r;
        ClothType = ty;
    }

    public Clothes(cloth_type ty)
    {
        ClothType = ty;
    }

    [Range(0f, 100f)] public float condition = 100;



    public cloth_type ClothType;

    public Vector3 Magic_Resist = Vector3.zero;
    //fire_r, ice_r, electric_r

    public Vector3 Physical_Resist = Vector3.zero;
    //slash_r, crash_r, prick_r

    [Range(0f, 100f)] public float dodge_chanse = 0;
}

public class Health_Indicators : MonoBehaviour {
    
    public Clothes[] Cloth = new Clothes[4];
    public Vector3 _Indicators_EE = new Vector3(100, 100, 100);
    public Vector3 Indicators
    {
        get
        {
            return _Indicators_EE;
        }
        set
        {
            Vector3 v = value;
            v.x = Mathf.Clamp(v.x, -1, Max_Indicator.x);
            v.y = Mathf.Clamp(v.y, -1, Max_Indicator.y);
            v.z = Mathf.Clamp(v.z, -1, Max_Indicator.z);
            _Indicators_EE = v;
        }
    }
    public Vector3 Max_Indicator = new Vector3(100, 100, 100);

    // Use this for initialization
    void Start () {
        //Indicators = Max_Indicator;
        Cloth[0] = new Clothes(cloth_type.Head);
        Cloth[1] = new Clothes(0, "Защитный плащ(Огонь)",cloth_type.Body, new Vector3(40, 0, 0), Vector3.zero);
        Cloth[2] = new Clothes(cloth_type.Leg);
        Cloth[3] = new Clothes(cloth_type.Foot);


    }

    // Update is called once per frame
    public Vector3 TakeHit(MagicSpell m_s)
    {
        Vector3 F_R = Vector3.zero;
        Vector3 FullDmg = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            F_R += Div(Cloth[i].Magic_Resist, new Vector3(400, 400, 400));
        }
        FullDmg = Mul(m_s.Damage, new Vector3(Mathf.Abs(F_R.x-1f), Mathf.Abs(F_R.y - 1f), Mathf.Abs(F_R.z - 1f)));
        Debug.Log("DMG = " + FullDmg);
        Indicators -= FullDmg;
        //UpdateIndicators();
        return Mul(FullDmg, Div(m_s.Absorb, new Vector3(100, 100, 100)));
    }

    public static Vector3 Mul(Vector3 one, Vector3 two)
    {
        return new Vector3(one.x * two.x, one.y * two.y, one.z * two.z);
    }

    public static Vector3 Div(Vector3 one, Vector3 two)
    {
        return new Vector3(one.x / two.x, one.y / two.y, one.z / two.z);
    }
}
