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
    public uint[] nextids;
    public SkillTree parent;

    public GroupPerkClass (uint[] _nextids, SkillTree _parent)
    {
        nextids = _nextids;
        parent = _parent;
    }

    public void TryLearn(bool console)
    {
        if (!CanBeLearned)
        {
            parent.parent.ShowMessage("Необходимо выучить предыдущие навыки.");
        }
    }
        /*else */
    }

[Serializable]
public class Perk
{
    public string name;
    public string Description;
    public uint[] nextids;
    public bool learned = false;
    public SkillTree SkillTreeObject;
    public Type SkillTreeType;
    public byte NeededLevelToLearn;
    public Action<object> action;

    public Perk(string _name, string _Description, uint[] _nextids, SkillTree _SkillTreeObject, Type _SkillTreeType, byte _NeededLevelToLearn, Action<object> _action)
    {
        name = _name;
        Description = _Description;
        nextids = _nextids;
        SkillTreeObject = _SkillTreeObject;
        SkillTreeType = _SkillTreeType;
        NeededLevelToLearn = _NeededLevelToLearn;
        action = _action;
    }

    public void TryLearn(bool console)
    {
        if (console)
        {
            LearnEnd();
        } else
        if (learned)
        {
            SkillTreeObject.parent.ShowMessage("Навык уже выучен.");
        }
        else if (SkillTreeObject.parent.GetSkillValue(SkillTreeObject.SkillType) < NeededLevelToLearn)
        {
            SkillTreeObject.parent.ShowMessage("У вас недостаточный уровень навыка " + SkillTreeObject.name + "."); //ActiveSkillTree
        } else 
        {
            LearnEnd();
        }
    }

    public void LearnEnd ()
    {
        learned = true;
        SkillTreeObject.RefreshVariables();
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
    private bool Apperentice;
    private bool Adept;
    private bool Expert;
    private bool Master;
    private bool Illusion_Dual_Casting;
    private bool Animage;
    private bool Kindred_Mage;
    private bool Quiet_Casting;
    private bool Hypnotic_Gaze;
    private bool Aspect_of_Terror;
    private bool Rage;
    private bool Master_of_the_Mind;

    private VisualPerk _VisualPerk = null;

    public IllusionTree(Player admin)
    {
        name = "Иллюзия";
        SkillType = SkillType.Illusion;
        GroupPerks = new GroupPerkClass[] { /**/};
        parent = admin;
    }

    public void SetVisualScript (VisualPerk vp)
    {
        _VisualPerk = vp;
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

    public class UpgradeTree : MonoBehaviour {
    public SkillType skillType;
    public Player player;

    /*public static obj[] AllObject = new obj[] {
        new obj(0x000F2CA9, typeof(Perk), new Perk("Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", new uint[] { 0x000153D0, 0x000C44C3, 0x000581E2 },  new perkUpgrade(0, delegate (object it) { (it as IllusionTree).Novice = true; Debug.Log("spell novice illusion learned");})))
    };*/

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
