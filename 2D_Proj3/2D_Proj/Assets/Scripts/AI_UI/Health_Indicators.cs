using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Indicators : MonoBehaviour {
    
    public Armor[] Cloth = new Armor[4];
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
        Cloth[0] = new Armor(armor_Type.Head);
        Cloth[1] = new Armor(0, "Защитный плащ(Огонь)", armor_Type.Body, new Vector3(40, 0, 0), Vector3.zero);
        Cloth[2] = new Armor(armor_Type.left_Foot);
        Cloth[3] = new Armor(armor_Type.right_Foot);


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
        return Mul(FullDmg, new Vector3(100, 100, 100)); //Div(m_s.Absorb, )
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
