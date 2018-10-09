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

[Serializable]
public class Perk
{
    public string name;
    public string Description;
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

    public void LearnEnd(Player player, uint GroupId)
    {
        player.GetTree(skillType).GroupPerks[GroupId].learned = true;
        player.GetTree(skillType).PerkLearnedAction(action);
        //typeof(SkillTreeType) p = (SkillTreeObject as SkillTreeType);
    }
}

public class GroupPerkClass
{
    public byte Number;
    public byte UpgradeLevel = 0;
    public bool CanBeLearned = false;
    public uint[] ids;
    public byte[] nextids;
    public bool learned = false;
    public SkillTree parent;

    public Perk FocusedPerk;

    public VisualPerk _VisualPerk = null;

    public GroupPerkClass (byte _Number, uint[] _ids, byte[] _nextids, bool _CanBeLearned, SkillTree _parent)
    {
        //Array.ForEach(_ids, x => (UpgradeTree.GetObject(x).Object as Perk).parent = this);
        Number = _Number;
        ids = _ids;
        nextids = _nextids;
        CanBeLearned = _CanBeLearned;
        parent = _parent;
        FocusedPerk = UpgradeTree.GetPerk(ids[UpgradeLevel]);
    }

    public bool TryLearn()
    {
        if (CanBeLearned == false)
        {
            parent.character.perkUpgradeMenu.ShowMessage("Необходимо выучить предыдущие навыки.");
        }
        else if (learned)
        {
            parent.character.perkUpgradeMenu.ShowMessage("Навык уже выучен.");
        }
        else if (parent.character.GetSkillValue(UpgradeTree.GetPerk(ids[UpgradeLevel]).skillType) < UpgradeTree.GetPerk(ids[UpgradeLevel]).NeededLevelToLearn)
        {
            parent.character.perkUpgradeMenu.ShowMessage("У вас недостаточный уровень навыка " + parent.name + "."); //ActiveSkillTree
        }
        else
        {
            UpgradeTree.GetPerk(ids[UpgradeLevel]).LearnEnd(parent.character, Number);
            UpgradeLevel++;
            if (nextids != null)
                if (nextids.Length > 0)
                    if (UpgradeLevel == 1)
                        Array.ForEach(nextids, x => { if (x < parent.GroupPerks.Length) if (parent.GroupPerks[x] != null) parent.GroupPerks[x].CanBeLearned = true; }); //UpgradeTree.GetPerk(x).Cas
            return true;
        }
        return false;
    }


    /*public void TryLearn(bool console, PerkUpgradeMenu _PerkUpgradeMenu)
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
    }*/
    /*else */
}


public class SkillTree
{
    public string name;
    public SkillType SkillType;
    public GroupPerkClass[] GroupPerks;
    public Player character;

    public SkillTree() { }

    public SkillTree(string _name, SkillType _SkillType, GroupPerkClass[] _GroupPerks)
    {
        name = _name;
        SkillType = _SkillType;
        GroupPerks = _GroupPerks;
    }

    public void PerkLearnedAction(Action<object> action)
    {
        action(this);
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

    public IllusionTree(Player _character)
    {
        name = "Иллюзия";
        SkillType = SkillType.Illusion;
        GroupPerks = new GroupPerkClass[] {
            new GroupPerkClass(0, new uint[] { 0x000f2ca9 }, new byte[] { 1, 5, 6, 9 }, true, this),
            new GroupPerkClass(1, new uint[] { 0x000c44c3 }, new byte[] { 2 }, false, this),
            new GroupPerkClass(2, new uint[] { 0x000c44c4 }, new byte[] { 3 }, false, this),
            new GroupPerkClass(3, new uint[] { 0x000c44c5 }, new byte[] { 4 }, false, this),
            new GroupPerkClass(4, new uint[] { 0x000c44c6 }, null, false, this),
            new GroupPerkClass(5, new uint[] { 0x000153d0 }, null, false, this),
            new GroupPerkClass(6, new uint[] { 0x000581e1 }, new byte[] { 7 }, false, this),
            new GroupPerkClass(7, new uint[] { 0x000581e2 }, new byte[] { 8 }, false, this),
            new GroupPerkClass(8, new uint[] { 0x000581fd }, new byte[] { 12 }, false, this),
            new GroupPerkClass(9, new uint[] { 0x00059b77 }, new byte[] { 10 }, false, this),
            new GroupPerkClass(10, new uint[] { 0x00059b78 }, new byte[] { 11 }, false, this),
            new GroupPerkClass(11, new uint[] { 0x000c44b5 }, new byte[] { 12 }, false, this),
            new GroupPerkClass(12, new uint[] { 0x00059b76 }, null, false, this),

        };
        character = _character;
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
        /*0 994473*/new ListObj(0x000f2ca9, typeof(Perk), new Perk("Новичок школы иллюзии", "Заклинания школы иллюзии уровня новичка расходуют вдвое меньше магии.", 0, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Novice = true; })),
        /*1 804035*/new ListObj(0x000c44c3, typeof(Perk), new Perk("Ученик школы иллюзии", "Заклинания школы иллюзии уровня ученика расходуют вдвое меньше магии.", 25, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Apperentice = true; })),
        /*2 804036*/new ListObj(0x000c44c4, typeof(Perk), new Perk("Адепт школы иллюзии", "Заклинания школы иллюзии уровня адепта расходуют вдвое меньше магии.", 50, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Adept = true; })),
        /*3 804037*/new ListObj(0x000c44c5, typeof(Perk), new Perk("Эксперт  школы иллюзии", "Заклинания школы иллюзии уровня эксперта расходуют вдвое меньше магии.", 75, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Expert = true; })),
        /*4 804038*/new ListObj(0x000c44c6, typeof(Perk), new Perk("Мастер  школы иллюзии", "Заклинания школы иллюзии уровня мастера расходуют вдвое меньше магии.", 100, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Master = true; })),
        /*5 86992*/new ListObj(0x000153d0, typeof(Perk), new Perk("Двойная иллюзия", "При сотворении заклинания школы иллюзий с двух рук получается его более сильный вариант.", 20, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Illusion_Dual_Casting = true; })),
        /*6 360929*/new ListObj(0x000581e1, typeof(Perk), new Perk("Обман животных", "Все заклинания иллюзии действуют на животных более высокого уровня.", 20, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Novice = true; })),
        /*7 360930*/new ListObj(0x000581e2, typeof(Perk), new Perk("Обман людских глаз", "Все заклинания иллюзии действуют на людей более высокого уровня", 40, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Novice = true; })),
        /*8 360957*/new ListObj(0x000581fd, typeof(Perk), new Perk("Бесшумные заклинания", "Вы творите любые заклинания любой школы магии бесшумно для других.", 50, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Novice = true; })),
        /*9 367479*/new ListObj(0x00059b77, typeof(Perk), new Perk("Гипнотический взгляд", "Заклинания успокоения применимы к противникам более высокого уровня. Сочетается с «Обманом людских глаз» и «Обманом животных».", 30, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Novice = true; })),
        /*10 367480*/new ListObj(0x00059b78, typeof(Perk), new Perk("Наука страха", "Заклинания страха применимы к противникам более высокого уровня. Сочетается с «Обманом людских глаз» и «Обманом животных».", 50, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Novice = true; })),
        /*11 804021*/new ListObj(0x000c44b5, typeof(Perk), new Perk("Неистовство", "Заклинания бешенства применимы к противникам более высокого уровня. Сочетается с «Обманом людских глаз» и «Обманом животных».", 70, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Novice = true; })),
        /*12 367478*/new ListObj(0x00059b76, typeof(Perk), new Perk("Мастер разума", "Заклинания школы иллюзии действуют на нежить, даэдра и механизмы.", 90, SkillType.Illusion, delegate (object it) { (it as IllusionTree).Master_of_the_Mind = true; })),
    };

    public static ListObj GetObject (uint value)
    {
        return Array.Find(AllObject, x => x.id == value);
    }

    public static Perk GetPerk(uint value)
    {
        return Array.Find(AllObject, x => x.id == value).Object as Perk;
    }

    public static Type GetTreeType(SkillType st)
    {
        Type result = null;
        switch (st)
        {
            case SkillType.Illusion: result = typeof(IllusionTree); break;
            case SkillType.Conjuration: result = typeof(SkillTree); break;
            case SkillType.Destruction: result = typeof(SkillTree); break;
            case SkillType.Restoration: result = typeof(SkillTree); break;
            case SkillType.Alteration: result = typeof(SkillTree); break;
            case SkillType.Enchanting: result = typeof(SkillTree); break;
            case SkillType.Smithing: result = typeof(SkillTree); break;
            case SkillType.HeavyArmor: result = typeof(SkillTree); break;
            case SkillType.Block: result = typeof(SkillTree); break;
            case SkillType.Twohanded: result = typeof(SkillTree); break;
            case SkillType.Onehanded: result = typeof(SkillTree); break;
            case SkillType.Marksman: result = typeof(SkillTree); break;
            case SkillType.LightArmor: result = typeof(SkillTree); break;
            case SkillType.Sneak: result = typeof(SkillTree); break;
            case SkillType.Lockpicking: result = typeof(SkillTree); break;
            case SkillType.Pickpocket: result = typeof(SkillTree); break;
            case SkillType.Speechcraft: result = typeof(SkillTree); break;
            case SkillType.Alchemy: result = typeof(SkillTree); break;
        }
        return result;
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
