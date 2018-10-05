using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class obj
{
    public uint id;
    public object Object;

    public obj (uint _id, object _Object)
    {
        id = _id;
        Object = _Object;
    }
}

    public class perkUpgrade
{
    public byte NeededLevel;
    public Action<object> action;
    public object parent;

    public perkUpgrade(byte _NeededLevel, Action<object> _action)
    {
        NeededLevel = _NeededLevel;
        action = _action; //(parent as skilltree)
    }

    public perkUpgrade(perkUpgrade pU, skilltree st)
    {
        NeededLevel = pU.NeededLevel;
        action = pU.action;
        parent = st;
    }
}

public class VisiblePerkField
{
    public byte UpgradeLevel = 0;
    public bool CanBeLearned;
    uint[] nextids;

    /*else if (!CanBeLearned)
        {
            parent.parent.ShowMessage("Необходимо выучить предыдущие навыки.");
        }*/
}

[Serializable]
public class pperk
{
    public string name;
    public string Description;
    public bool learned;
    public perkUpgrade perkUpgradeLevel;
    public skilltree parent;

    public pperk(string _name, string _Description, uint[] _nextids, perkUpgrade _perkUpgradeLevel)
    {
        name = _name;
        Description = _Description;
        _perkUpgradeLevel.parent = parent;
        perkUpgradeLevel = _perkUpgradeLevel;
    }

    public void TryLearn()
    {
        if (learned)
        {
            parent.parent.ShowMessage("Навык уже выучен.");
        }
        else if ((parent.parent.Illusion) < perkUpgradeLevel.NeededLevel)
        {
            parent.parent.ShowMessage("У вас недостаточный уровень навыка " + parent.name + "."); //ActiveSkillTree
        }
        else
        {
            parent.LearnPerk(id);
        }
    }
}

public class skilltree
{
    public string name;
    public skillType SkillType;
    public pperk[] perks;
    public Player parent;

    public skilltree() { }

    public skilltree(string _name, skillType _SkillType, pperk[] _perks)
    {
        name = _name;
        SkillType = _SkillType;
        perks = _perks;
    }

    public void LearnPerk(uint u)
    {
        if (parent.FreePerkPoints < 1)
        {
            parent.ShowMessage("Недостаточно очков навыков.");
        }
        else
        {

            pperk p = Array.Find(perks, x => x.id == u);
            if (p != null)
            {

                /*if (p.UpgradeLevel < p.perkUpgradeLevels.Length)
                {
                    Array.ForEach(perks, x => { x.CanBeLearned = true; });
                    p.perkUpgradeLevels[p.UpgradeLevel].action(this);
                    parent.FreePerkPoints--;
                    parent.UpgradePerkPointsText();
                    p.UpgradeLevel++;
                }*/
            }
        }
    }
}

public class IllusionTree : skilltree
{
    public bool Novice;
    private bool Apperentice;
    private bool Adept;
    private bool Expert;
    private bool Master;
    private bool DualCasting;

    private Action upgrade;



    public IllusionTree(string _name, skillType _SkillType, pperk[] _perks)
    {
        name = _name;
        SkillType = _SkillType;
        perks = _perks;
    }

}

public class UpgradeTree : MonoBehaviour {
    public skillType SkillType;
    public Player player;

    public static obj[] AllObject = new obj[] {
        new obj(0x000F2CA9, new pperk("Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", new uint[] { 0x000153D0, 0x000C44C3, 0x000581E2 },  new perkUpgrade(0, delegate (object it) { (it as IllusionTree).Novice = true; Debug.Log("spell novice illusion learned");/**/})))
    };

    public IllusionTree Illusion = new IllusionTree("Иллюзия", (skillType)0, new pperk[] {
        new pperk("Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", new uint[] { 0x000153D0, 0x000C44C3, 0x000581E2 },  new perkUpgrade(0, delegate (object it) { (it as IllusionTree).Novice = true; Debug.Log("spell novice illusion learned");/**/})), 
        //delegate (perkUpgrade p) { (parent as IllusionTree).Novice = true;/**/ }, 0x000F2CA9
        //new pperk(0x000F2CA9, "Двойная иллюзия", "При сотворении заклинания школы иллюзий с двух рук получается его более сильный вариант.", null, new perkUpgrade[] { new perkUpgrade(20, delegate () { (parent as IllusionTree).Novice = true;/**/ }) })
    });

    void Start()
    {
        
        //Illusion
        //Action myAction = delegate () { int i = 1; };// void { int i = 1; }; //new Action<>(
    }
}
