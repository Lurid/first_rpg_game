using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VisualPerk : MonoBehaviour {
    public uint FirstPerkId;

    private GroupPerkClass ThisPerk;

    public Text lvl;
    public Text PerkName;
    public Image learnedIMG;
    public Player player;

    private float LastClickTime;

    void Start () {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (FirstPerkId != 0)
        {
            //Debug.Log((UpgradeTree.GetPerk(FirstPerkId)).name);
            //Debug.Log(player.GetTree((UpgradeTree.GetPerk(FirstPerkId).skillType))); //.GroupPerks[0].ids[0]
            ThisPerk = Array.Find(player.GetTree((UpgradeTree.GetObject(FirstPerkId).Object as Perk).skillType).GroupPerks, x => x.ids[0] == FirstPerkId);
            if (ThisPerk != null)
            {
                lvl.text = (ThisPerk.FocusedPerk.NeededLevelToLearn) + "lvl";
                PerkName.text = ThisPerk.FocusedPerk.name;
                //tree = transform.GetComponentInParent<UpgradeTree>();
            }
            //Debug.Log(ThisPerk);
            //ThisPerk = Array.Find(player.GetTree((UpgradeTree.GetObject(FirstPerkId).Object as Perk).skillType).GroupPerks, x => { uint k = Array.Find(x.ids, y => y == FirstPerkId); if (k != 0) Debug.Log("!@!"); return k != 0; });
        }
        //ThisPerk = 
    }
	
	public void Enter () {
        //tree.Bottom.text = Description;

    }

    public void Exit()
    {
        //tree.Bottom.text = "";
    }

    public void Click()
    {
        if (FirstPerkId != 0)
        {
            if ((Time.time - LastClickTime) < 0.5f)
            {
                if (FirstPerkId != 0)
                {
                    bool leared = ThisPerk.TryLearn();
                    if (leared) LearnThisPerk();
                }
            }
            else
            {
                player.perkUpgradeMenu.UpgradeDescriptionText(ThisPerk);
                player.perkUpgradeMenu.ShowNeededLevelValue(ThisPerk);
            }
        }
        LastClickTime = Time.time;
    }

    public void LearnThisPerk()
    {
        //ThisPerk.UpgradeLevel++;
        learnedIMG.enabled = true;
        
    }

}
