using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ListObj
{
    public uint id;
    public Type type;
    public object Object;

    public ListObj(uint _id,Type _type, object _Object)
    {
        id = _id;
        type = _type;
        Object = _Object;
    }
}

public class GroupPerkClass
{
    public byte UpgradeLevel = 0;
    public bool CanBeLearned = false;
    public uint[] ids;
    public uint[] nextids;
    public SkillTree parent;

    public VisualPerk _VisualPerk = null;

    public GroupPerkClass (uint[] _ids, uint[] _nextids, bool _CanBeLearned, SkillTree _parent)
    {
        //Array.ForEach(_ids, x => (UpgradeTree.GetObject(x).Object as Perk).parent = this);
        ids = _ids;
        nextids = _nextids;
        CanBeLearned = _CanBeLearned;
        parent = _parent;

    }

    public void TryLearn()
    {
        if (!CanBeLearned)
        {
            parent.parent.perkUpgradeMenu.ShowMessage("Необходимо выучить предыдущие навыки.");
        } else
        {
            UpgradeTree.GetPerk(ids[UpgradeLevel]).TryLearn(false);
        }
    }


    public void TryLearn(bool console, PerkUpgradeMenu _PerkUpgradeMenu)
    {
        Perk p = UpgradeTree.GetPerk(ids[UpgradeLevel]);
        if (console)
        {
            p.LearnEnd();
        }
        if (!CanBeLearned)
        {
            parent.parent.perkUpgradeMenu.ShowMessage("Необходимо выучить предыдущие навыки.");
        } else if (learned)
        {
            _PerkUpgradeMenu.ShowMessage("Навык уже выучен.");
        }
        else if (_PerkUpgradeMenu.GetSkillValue(skillType) < NeededLevelToLearn)
        {
            _PerkUpgradeMenu.ShowMessage("У вас недостаточный уровень навыка " + SkillTreeObject.name + "."); //ActiveSkillTree
        }
        else
        {
            p.LearnEnd();
        }
        SkillTreeObject.RefreshVariables();
    }
    /*else */
}

[Serializable]
public class Perk
{
    public string name;
    public string Description;
    public bool learned = false;
    public byte NeededLevelToLearn;
    public SkillType skillType;
    public Action<object> action;

    public Perk(string _name, string _Description, byte _NeededLevelToLearn, SkillType _skillType, Action<object> _action)
    {
        name = _name;
        Description = _Description;
        NeededLevelToLearn = _NeededLevelToLearn;
        skillType = _skillType;
        action = _action;
    }

    public void LearnEnd ()
    {
        learned = true;
        //typeof(SkillTreeType) p = (SkillTreeObject as SkillTreeType);
    }
}

public class SkillTree
{
    public string name;
    public SkillType SkillType;
    public GroupPerkClass[] GroupPerks;
    public Player parent;

    public SkillTree() { }

    public SkillTree(string _name, SkillType _SkillType, GroupPerkClass[] _GroupPerks)
    {
        name = _name;
        SkillType = _SkillType;
        GroupPerks = _GroupPerks;
    }

    public void RefreshVariables()
    {

    }
}

public class IllusionTree : SkillTree
{
    public bool Novice;
    public bool Apperentice;
    public bool Adept;
    public bool Expert;
    public bool Master;
    public bool Illusion_Dual_Casting;
    public bool Animage;
    public bool Kindred_Mage;
    public bool Quiet_Casting;
    public bool Hypnotic_Gaze;
    public bool Aspect_of_Terror;
    public bool Rage;
    public bool Master_of_the_Mind;

    public VisualPerk[] perks;

    public IllusionTree(Player admin)
    {
        name = "Иллюзия";
        SkillType = SkillType.Illusion;
        GroupPerks = new GroupPerkClass[] { new GroupPerkClass(new uint[] { 0x000F2CA9 }, new uint[] { 0x000581e1, 0x000c44c3, 0x00059b77, 0x000153d0 }, true, this) };
        parent = admin;
    }

    public void SetVisualScript (byte index, VisualPerk vp)
    {
        GroupPerks[index]._VisualPerk = vp;
    }

    /*public IllusionTree(string _name, skillType _SkillType, pperk[] _perks)
    {
        name = _name;
        SkillType = _SkillType;
        perks = _perks;
    }*/

    /*public void LearnPerk(uint u)
    {
        if (parent.FreePerkPoints < 1)
        {
            parent.ShowMessage("Недостаточно очков навыков.");
        }
        else
        {

            VisualPerkClass p = Array.Find(perks, x => x.id == u);
            if (p != null)
            {

                if (p.UpgradeLevel < p.perkUpgradeLevels.Length)
                {
                    Array.ForEach(perks, x => { x.CanBeLearned = true; });
                    p.perkUpgradeLevels[p.UpgradeLevel].action(this);
                    parent.FreePerkPoints--;
                    parent.UpgradePerkPointsText();
                    p.UpgradeLevel++;
                }
            }
        }*/
}

//static int jj;


public class UpgradeTree : MonoBehaviour {
    public SkillType skillType;
    public Player player;

    public static ListObj[] AllObject = new ListObj[] {
        new ListObj(0x000F2CA9, typeof(Perk), new Perk("Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", 0, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Novice = true; Debug.Log("spell novice illusion learned");}))
    };

    public static ListObj GetObject (uint value)
    {
        return Array.Find(AllObject, x => x.id == value);
    }

    public static Perk GetPerk(uint value)
    {
        return Array.Find(AllObject, x => x.id == value).Object as Perk;
    }

    /*public IllusionTree Illusion = new IllusionTree("Иллюзия", (skillType)0, new pperk[] {
            new Perk("Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", new uint[] { 0x000153D0, 0x000C44C3, 0x000581E2 },  new perkUpgrade(0, delegate (object it) { (it as IllusionTree).Novice = true; Debug.Log("spell novice illusion learned");/**/  //})), */

    //delegate (perkUpgrade p) { (parent as IllusionTree).Novice = true;/**/ }, 0x000F2CA9
    //new pperk(0x000F2CA9, "Двойная иллюзия", "При сотворении заклинания школы иллюзий с двух рук получается его более сильный вариант.", null, new perkUpgrade[] { new perkUpgrade(20, delegate () { (parent as IllusionTree).Novice = true;/**/ }) })
    //});

    void Start()
    {
        
        //Illusion
        //Action myAction = delegate () { int i = 1; };// void { int i = 1; }; //new Action<>(
    }
}
