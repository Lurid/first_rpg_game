using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum skillType
{
    Illusion, Conjuration, Destruction, Restoration, Alteration, Enchanting,
    Smithing, HeavyArmor, Block, Twohanded, Onehanded, Marksman,
    LightArmor, Sneak, Lockpicking, Pickpocket, Speechcraft, Alchemy,
    None
}

public class Player : MonoBehaviour {
    public ushort FreePerkPoints;
    
    public byte Illusion = 15; public byte Conjuration = 15; public byte Destruction = 15; public byte Restoration = 15; public byte Alteration = 15; public byte Enchanting = 15;
    public byte Smithing = 15; public byte HeavyArmor = 15; public byte Block = 15; public byte Twohanded = 15; public byte Onehanded = 15; public byte Marksman = 15;
    public byte LightArmor = 15; public byte Sneak = 15; public byte Lockpicking = 15; public byte Pickpocket = 15; public byte Speechcraft = 15; public byte Alchemy = 15;

    public UpgradeTree IllusionTree; public UpgradeTree ConjurationTree; public UpgradeTree DestructionTree; public UpgradeTree RestorationTree; public UpgradeTree AlterationTree; public UpgradeTree EnchantingTree;
    public UpgradeTree SmithingTree; public UpgradeTree HeavyArmorTree; public UpgradeTree BlockTree; public UpgradeTree TwohandedTree; public UpgradeTree OnehandedTree; public UpgradeTree MarksmanTree;
    public UpgradeTree LightArmorTree; public UpgradeTree SneakTree; public UpgradeTree LockpickingTree; public UpgradeTree PickpocketTree; public UpgradeTree SpeechcraftTree; public UpgradeTree AlchemyTree;


    public UpgradeTree ActiveSkillTree;

    public Text TreeUpgradeTextName;
    public Text SpellDescriptionTreeUpgradeText;
    public Text PerkPointsText;
    public Text RightTreeInfo;
    public Text LeftTreeInfo;
    public Text MessageTreeUpgradeText;

    void Start () {
        FreePerkPoints = 20;
        UpgradeSkillPointsText();
        UpgradePerkPointsText();
    }
	
	public void TryLernPerk (pperk p) {
        //Debug.Log(p.Name + " clicked");
        //UpgradeTree ActiveTree = p.parent;
        if (!p.CanBeLearned) //&& (FreePerkPoints > 0) && (Illusion > p.NeededLevel) && (!p.learned)
        {
            ShowMessage("Необходимо выучить предыдущие навыки.");
        }
        else if (GetSkillValue(p.parent.SkillType) < p.perkUpgradeLevels[p.UpgradeLevel].NeededLevel)
        {
            ShowMessage("У вас недостаточный уровень навыка " + ActiveSkillTree.name + "."); //ActiveSkillTree
        }
        else if (FreePerkPoints < 1)
        {
            ShowMessage("Недостаточно очков навыков.");
        }
        else if (p.learned)
        {
            ShowMessage("Навык уже выучен.");
        } else 
        {
            FreePerkPoints--;
            UpgradePerkPointsText();
            p.parent.LearnThisPerk(p.id);
        }
    }
    
    public void ShowMessage(string message)
    {
        MessageTreeUpgradeText.text = message;
    }

    public void UpgradeSkillPointsText()
    {
        RightTreeInfo.text = ActiveSkillTree.name + " : " + GetSkillValue(ActiveSkillTree.SkillType);
    }

    public void UpgradePerkPointsText ()
    {
        PerkPointsText.text = "Свободных очков способностей: " + FreePerkPoints;
    }

    public void UpgradeDescriptionText(string desc)
    {
        SpellDescriptionTreeUpgradeText.text = desc;
    }
    

    public UpgradeTree GetTree(skillType sT)
    {
        UpgradeTree result = null;
        switch (sT)
        {
            case skillType.Illusion: result = IllusionTree; break;
            case skillType.Conjuration: result = ConjurationTree; break;
            case skillType.Destruction: result = DestructionTree; break;
            case skillType.Restoration: result = RestorationTree; break;
            case skillType.Alteration: result = AlterationTree; break;
            case skillType.Enchanting: result = EnchantingTree; break;
            case skillType.Smithing: result = SmithingTree; break;
            case skillType.HeavyArmor: result = HeavyArmorTree; break;
            case skillType.Block: result = BlockTree; break;
            case skillType.Twohanded: result = TwohandedTree; break;
            case skillType.Onehanded: result = OnehandedTree; break;
            case skillType.Marksman: result = MarksmanTree; break;
            case skillType.LightArmor: result = LightArmorTree; break;
            case skillType.Sneak: result = SneakTree; break;
            case skillType.Lockpicking: result = LockpickingTree; break;
            case skillType.Pickpocket: result = PickpocketTree; break;
            case skillType.Speechcraft: result = SpeechcraftTree; break;
            case skillType.Alchemy: result = AlchemyTree; break;
        }
        return result;
    }

    public byte GetSkillValue (skillType sT)
    {
        byte result = 0;
        switch (sT)
        {
            case skillType.Illusion: result = Illusion; break;
            case skillType.Conjuration: result = Conjuration; break;
            case skillType.Destruction: result = Destruction; break;
            case skillType.Restoration: result = Restoration; break;
            case skillType.Alteration: result = Alteration; break;
            case skillType.Enchanting: result = Enchanting; break;
            case skillType.Smithing: result = Smithing; break;
            case skillType.HeavyArmor: result = HeavyArmor; break;
            case skillType.Block: result = Block; break;
            case skillType.Twohanded: result = Twohanded; break;
            case skillType.Onehanded: result = Onehanded; break;
            case skillType.Marksman: result = Marksman; break;
            case skillType.LightArmor: result = LightArmor; break;
            case skillType.Sneak: result = Sneak; break;
            case skillType.Lockpicking: result = Lockpicking; break;
            case skillType.Pickpocket: result = Pickpocket; break;
            case skillType.Speechcraft: result = Speechcraft; break;
            case skillType.Alchemy: result = Alchemy; break;
        }
    return result;
    }
}
