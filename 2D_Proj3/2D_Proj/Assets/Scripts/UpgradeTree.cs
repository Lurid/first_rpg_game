using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class perkUpgrade
{
    byte NeededLevel;
    Action action;

    public perkUpgrade (byte _NeededLevel, Action _action)
    {
        NeededLevel = _NeededLevel;
        action = _action;
    }
}

public class pperk
{
    uint id;
    string name;
    string description;
    uint[] nextids;
    public perkUpgrade[] perkUpgradeLevels;

    public pperk(uint _id, string _name, string _description, uint[] _nextids, perkUpgrade[] _perkUpgradeLevels)
    {
        id = _id;
        name = _name;
        description = _description;
        nextids = _nextids;
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
}

public class UpgradeTree : MonoBehaviour {
    public string SkillName;
    public Text Upper;
    public Text Bottom;
    public skillType SkillType;
    public Player player;

    public skilltree Illusion = new skilltree("Иллюзия", (skillType)0, new pperk[] {
        new pperk(0x000F2CA9, "Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", new uint[] { 0x000153D0, 0x000C44C3, 0x000581E2 }, new perkUpgrade[] { new perkUpgrade(0, delegate () { /**/ })}),
        new pperk(0x000F2CA9, "Двойная иллюзия", "При сотворении заклинания школы иллюзий с двух рук получается его более сильный вариант.", new uint[] { 0x000153D0, 0x000C44C3, 0x000581E2 }, new perkUpgrade[] { new perkUpgrade(0, delegate () { /**/ })})
    });

    void Start()
    {
        UpgradeSkillPointsText();
        //Action myAction = delegate () { int i = 1; };// void { int i = 1; }; //new Action<>(
    }

    public void UpgradeSkillPointsText()
    {
        Upper.text = "Уровень навыка "+ SkillName + ": " + transform.GetComponentInParent<Player> ().GetSkillValue(SkillType);
    }
}
