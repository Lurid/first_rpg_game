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
        FreePerkPoints = 10;
        UpgradePerkPointsText();
    }
	
	public void TryLernPerk (Perk p) {
        Debug.Log(p.Name + " clicked");
        if ((p.CanBeLearned) && (FreePerkPoints > 0) && (Illusion > p.NeededLevel) && (!p.learned))
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
}
