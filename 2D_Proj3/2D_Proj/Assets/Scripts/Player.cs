using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    Illusion, Conjuration, Destruction, Restoration, Alteration, Enchanting,
    Smithing, HeavyArmor, Block, Twohanded, Onehanded, Marksman,
    LightArmor, Sneak, Lockpicking, Pickpocket, Speechcraft, Alchemy,
    None
}

public class Player : MonoBehaviour {
    public bool isPlayer = false;
    public ushort FreePerkPoints;

    public uint Level = 1;
    
    public byte Illusion = 15; public byte Conjuration = 15; public byte Destruction = 15; public byte Restoration = 15; public byte Alteration = 15; public byte Enchanting = 15;
    public byte Smithing = 15; public byte HeavyArmor = 15; public byte Block = 15; public byte Twohanded = 15; public byte Onehanded = 15; public byte Marksman = 15;
    public byte LightArmor = 15; public byte Sneak = 15; public byte Lockpicking = 15; public byte Pickpocket = 15; public byte Speechcraft = 15; public byte Alchemy = 15;

    public IllusionTree IllusionTree; public SkillTree ConjurationTree; public SkillTree DestructionTree; public SkillTree RestorationTree; public SkillTree AlterationTree; public SkillTree EnchantingTree;
    public SkillTree SmithingTree; public SkillTree HeavyArmorTree; public SkillTree BlockTree; public SkillTree TwohandedTree; public SkillTree OnehandedTree; public SkillTree MarksmanTree;
    public SkillTree LightArmorTree; public SkillTree SneakTree; public SkillTree LockpickingTree; public SkillTree PickpocketTree; public SkillTree SpeechcraftTree; public SkillTree AlchemyTree;
    
    public UpgradeTree IllusionVisual; public UpgradeTree ConjurationVisual; public UpgradeTree DestructionVisual; public UpgradeTree RestorationVisual; public UpgradeTree AlterationVisual; public UpgradeTree EnchantingVisual;
    public UpgradeTree SmithingVisual; public UpgradeTree HeavyArmorVisual; public UpgradeTree BlockVisual; public UpgradeTree TwohandedVisual; public UpgradeTree OnehandedVisual; public UpgradeTree MarksmanVisual;
    public UpgradeTree LightArmorVisual; public UpgradeTree SneakVisual; public UpgradeTree LockpickingVisual; public UpgradeTree PickpocketVisual; public UpgradeTree SpeechcraftVisual; public UpgradeTree AlchemyVisual;

    public SkillTree ActiveSkillTree;

    public Text TreeUpgradeTextName;
    public Text SpellDescriptionTreeUpgradeText;
    public Text PerkPointsText;
    public Text RightTreeInfo;
    public Text LeftTreeInfo;
    public Text MessageTreeUpgradeText;

    private void Awake()
    {
        IllusionTree = new IllusionTree(this);
    }

    void Start () {

        /*if (GetComponent<Gamer>() != null)
        {
            IllusionTree.SetVisualScript(0, GetVisual(IllusionTree.SkillType));
        }*/
        FreePerkPoints = 20;
        ActiveSkillTree = IllusionTree;
        UpgradeSkillPointsText();
        UpgradePerkPointsText();
    }
	
	public void TryLernPerk (Perk p) {
        //Debug.Log(p.Name + " clicked");
        //UpgradeTree ActiveTree = p.parent;

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

    public void UpgradeDescriptionText(Perk p)
    {
        SpellDescriptionTreeUpgradeText.text = p.Description;
    }

    public void UpgradeDescriptionText(GroupPerkClass p)
    {
        Debug.Log(p);
        SpellDescriptionTreeUpgradeText.text = (UpgradeTree.GetObject(p.ids[p.UpgradeLevel]).Object as Perk).Description;
    }


    public SkillTree GetTree(SkillType sT)
    {
        SkillTree result = null;
        switch (sT)
        {
            case SkillType.Illusion: result = IllusionTree; break;
            case SkillType.Conjuration: result = ConjurationTree; break;
            case SkillType.Destruction: result = DestructionTree; break;
            case SkillType.Restoration: result = RestorationTree; break;
            case SkillType.Alteration: result = AlterationTree; break;
            case SkillType.Enchanting: result = EnchantingTree; break;
            case SkillType.Smithing: result = SmithingTree; break;
            case SkillType.HeavyArmor: result = HeavyArmorTree; break;
            case SkillType.Block: result = BlockTree; break;
            case SkillType.Twohanded: result = TwohandedTree; break;
            case SkillType.Onehanded: result = OnehandedTree; break;
            case SkillType.Marksman: result = MarksmanTree; break;
            case SkillType.LightArmor: result = LightArmorTree; break;
            case SkillType.Sneak: result = SneakTree; break;
            case SkillType.Lockpicking: result = LockpickingTree; break;
            case SkillType.Pickpocket: result = PickpocketTree; break;
            case SkillType.Speechcraft: result = SpeechcraftTree; break;
            case SkillType.Alchemy: result = AlchemyTree; break;
        }
        return result;
    }

    public UpgradeTree GetVisual(SkillType ST)
    {
        UpgradeTree result = null;
        switch (ST)
        {
            case SkillType.Illusion: result = IllusionVisual; break;
            case SkillType.Conjuration: result = ConjurationVisual; break;
            case SkillType.Destruction: result = DestructionVisual; break;
            case SkillType.Restoration: result = RestorationVisual; break;
            case SkillType.Alteration: result = AlterationVisual; break;
            case SkillType.Enchanting: result = EnchantingVisual; break;
            case SkillType.Smithing: result = SmithingVisual; break;
            case SkillType.HeavyArmor: result = HeavyArmorVisual; break;
            case SkillType.Block: result = BlockVisual; break;
            case SkillType.Twohanded: result = TwohandedVisual; break;
            case SkillType.Onehanded: result = OnehandedVisual; break;
            case SkillType.Marksman: result = MarksmanVisual; break;
            case SkillType.LightArmor: result = LightArmorVisual; break;
            case SkillType.Sneak: result = SneakVisual; break;
            case SkillType.Lockpicking: result = LockpickingVisual; break;
            case SkillType.Pickpocket: result = PickpocketVisual; break;
            case SkillType.Speechcraft: result = SpeechcraftVisual; break;
            case SkillType.Alchemy: result = AlchemyVisual; break;
        }
        return result;
    }

    public byte GetSkillValue (SkillType sT)
    {
        byte result = 0;
        switch (sT)
        {
            case SkillType.Illusion: result = Illusion; break;
            case SkillType.Conjuration: result = Conjuration; break;
            case SkillType.Destruction: result = Destruction; break;
            case SkillType.Restoration: result = Restoration; break;
            case SkillType.Alteration: result = Alteration; break;
            case SkillType.Enchanting: result = Enchanting; break;
            case SkillType.Smithing: result = Smithing; break;
            case SkillType.HeavyArmor: result = HeavyArmor; break;
            case SkillType.Block: result = Block; break;
            case SkillType.Twohanded: result = Twohanded; break;
            case SkillType.Onehanded: result = Onehanded; break;
            case SkillType.Marksman: result = Marksman; break;
            case SkillType.LightArmor: result = LightArmor; break;
            case SkillType.Sneak: result = Sneak; break;
            case SkillType.Lockpicking: result = Lockpicking; break;
            case SkillType.Pickpocket: result = Pickpocket; break;
            case SkillType.Speechcraft: result = Speechcraft; break;
            case SkillType.Alchemy: result = Alchemy; break;
        }
    return result;
    }
}
