using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerkUpgradeMenu : MonoBehaviour {
    public Player gamer;

    public Text SkillTreeNameText;
    public Text PerkDescriptionText;
    public Text FreePointsText;
    public Text RightInfo;
    public Text LeftInfo;
    public Text WarningMessageText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSkillTreeName(SkillTree st)
    {
        SkillTreeNameText.text = st.name;
    }

    public void ShowMessage(string message)
    {
        WarningMessageText.text = message;
    }

    public void ShowNeededLevelValue(GroupPerkClass group)
    {
        LeftInfo.text = "Необходимо : " + ((UpgradeTree.GetObject(group.ids[group.UpgradeLevel]).Object as Perk).NeededLevelToLearn);
    }

    public void ShowSkillTreeValue(SkillTree ActiveSkillTree)
    {
        RightInfo.text = ActiveSkillTree.name + " : " + gamer.GetSkillValue(ActiveSkillTree.SkillType);
    }

    public void UpgradeFreePointsText()
    {
        FreePointsText.text = "Свободных очков способностей: " + gamer.FreePerkPoints;
    }

    public void UpgradeDescriptionText(Perk p)
    {
        PerkDescriptionText.text = p.Description;
    }

    public void UpgradeDescriptionText(GroupPerkClass p)
    {
        PerkDescriptionText.text = (UpgradeTree.GetPerk(p.ids[p.UpgradeLevel])).Description;
    }
}
