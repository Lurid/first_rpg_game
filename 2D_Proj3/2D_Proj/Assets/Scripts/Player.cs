using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum skillType
{
    Illusion, Conjuration, Destruction, Restoration, Alteration, Enchanting,
    Smithing, HeavyArmor, Block, Twohanded, Onehanded, Marksman,
    LightArmor, Sneak, Lockpicking, Pickpocket, Speechcraft, Alchemy
}

public class Player : MonoBehaviour {
    public ushort FreePerkPoints;
    
    public byte Illusion = 15; public byte Conjuration = 15; public byte Destruction = 15; public byte Restoration = 15; public byte Alteration = 15; public byte Enchanting = 15;
    public byte Smithing = 15; public byte HeavyArmor = 15; public byte Block = 15; public byte Twohanded = 15; public byte Onehanded = 15; public byte Marksman = 15;
    public byte LightArmor = 15; public byte Sneak = 15; public byte Lockpicking = 15; public byte Pickpocket = 15; public byte Speechcraft = 15; public byte Alchemy = 15;

    public Text PerkPointsText;

    void Start () {
        FreePerkPoints = 20;
        UpgradePerkPointsText();
    }
	
	public void TryLernPerk (Perk p) {
        //Debug.Log(p.Name + " clicked");
        if (!p.CanBeLearned) //&& (FreePerkPoints > 0) && (Illusion > p.NeededLevel) && (!p.learned)
        {
            Debug.Log("Необходимо выучить предыдущие навыки.");
        }
        else if (Illusion < p.NeededLevel)
        {
            Debug.Log("У вас недостаточный уровень навыка " + p.tree.SkillName + ".");
        }
        else if (FreePerkPoints < 1)
        {
            Debug.Log("Недостаточно очков навыков.");
        }
        else if (p.learned)
        {
            Debug.Log("Навык уже выучен.");
        } else 
        {
            FreePerkPoints--;
            UpgradePerkPointsText();
            p.LearnThisPerk();
        }
    }

    public void UpgradePerkPointsText ()
    {
        PerkPointsText.text = "Свободных очков способностей: " + FreePerkPoints;
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
