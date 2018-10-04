using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class perkUpgrade
{
    byte NeededLevel;
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

[Serializable]
public class pperk
{
    public uint id;
    string name;
    string description;
    public byte UpgradeLevel;
    uint[] nextids;
    public perkUpgrade[] perkUpgradeLevels;
    public skilltree parent;

    public pperk(uint _id, string _name, string _description, uint[] _nextids, perkUpgrade[] _perkUpgradeLevels)
    {
        id = _id;
        name = _name;
        description = _description;
        nextids = _nextids;
        Array.ForEach(_perkUpgradeLevels, x => { x.parent = parent; });
        perkUpgradeLevels = _perkUpgradeLevels;
    }
}

public class skilltree
{
    public string name;
    public skillType SkillType;
    public pperk[] perks;

    public skilltree(string _name, skillType _SkillType, pperk[] _perks)
    {
        name = _name;
        SkillType = _SkillType;
        perks = _perks;
    }

    public skilltree(){ }
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

    public void LearnPerk(uint u)
    {
        pperk p = Array.Find(perks, x => x.id == u);
        p.perkUpgradeLevels[p.UpgradeLevel].action(this); //upgrade = 
        upgrade.Invoke();
        p.UpgradeLevel++;
    }

    public IllusionTree(string _name, skillType _SkillType, pperk[] _perks)
    {
        name = _name;
        SkillType = _SkillType;
        perks = _perks;
    }

}

public class UpgradeTree : MonoBehaviour {
    public string SkillName;
    public Text Upper;
    public Text Bottom;
    public skillType SkillType;
    public Player player;

    public IllusionTree Illusion = new IllusionTree("Иллюзия", (skillType)0, new pperk[] {
        new pperk(0x000F2CA9, "Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", new uint[] { 0x000153D0, 0x000C44C3, 0x000581E2 }, new perkUpgrade[] { new perkUpgrade(0, delegate (object it) { (it as IllusionTree).Novice = true;/**/ }) }), //delegate (perkUpgrade p) { (parent as IllusionTree).Novice = true;/**/ }, 0x000F2CA9
        //new pperk(0x000F2CA9, "Двойная иллюзия", "При сотворении заклинания школы иллюзий с двух рук получается его более сильный вариант.", null, new perkUpgrade[] { new perkUpgrade(20, delegate () { (parent as IllusionTree).Novice = true;/**/ }) })
    });

    void Start()
    {
        UpgradeSkillPointsText();
        //Illusion
        //Action myAction = delegate () { int i = 1; };// void { int i = 1; }; //new Action<>(
    }

    public void UpgradeSkillPointsText()
    {
        Upper.text = "Уровень навыка "+ SkillName + ": " + transform.GetComponentInParent<Player> ().GetSkillValue(SkillType);
    }
}
