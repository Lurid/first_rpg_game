using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class perkUpgrade
{
    byte NeededLevel;
}

public class pperk
{
    uint id;
    string name;
    string description;
    uint[] nextids;

    public pperk(uint _id, string _name, string _description, uint[] _nextids)
    {
        id = _id;
        name = _name;
        description = _description;
        nextids = _nextids;
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

    public skilltree Illusion = new skilltree("Иллюзия", (skillType)0, new pperk[] {
        new pperk(0x000F2CA9, "Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", new uint[] { 0x000153D0, 0x000C44C3, 0x000581E2 })
    });

    void Start()
    {
        UpgradeSkillPointsText();

    }

    public void UpgradeSkillPointsText()
    {
        Upper.text = "Уровень навыка "+ SkillName + ": " + transform.GetComponentInParent<Player> ().GetSkillValue(SkillType);
    }
}
