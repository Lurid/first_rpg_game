using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VisualPerk : MonoBehaviour {
    public uint code;

    private GroupPerkClass ThisPerk;

    public Text lvl;
    public Text namee;
    public Image learnedIMG;
    public Player player;

    private float LastClickTime;

    void Start () {
        /*if (ThisPerk != null) {
            lvl.text = (ThisPerk.perkUpgradeLevel.NeededLevel) + "lvl";
            name.text = ThisPerk.name;
            tree = transform.GetComponentInParent<UpgradeTree>();
        }*/
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (code != 0)
        {
            Debug.Log((UpgradeTree.GetPerk(code)).name);
            Debug.Log(player.GetTree((UpgradeTree.GetObject(code).Object as Perk).skillType)); //.GroupPerks[0].ids[0]
            ThisPerk = Array.Find(player.GetTree((UpgradeTree.GetObject(code).Object as Perk).skillType).GroupPerks, x => { uint k = Array.Find(x.ids, y => y == code); if (k != 0) Debug.Log("!@!"); return k != 0; } );
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
        if ((Time.time - LastClickTime) < 0.5f)
        {
            if (code != 0) ThisPerk.TryLearn();
        } else
        {
            player.perkUpgradeMenu.UpgradeDescriptionText(ThisPerk);
            player.perkUpgradeMenu.ShowNeededLevelValue(ThisPerk);
        }
        LastClickTime = Time.time;
    }

    public void LearnThisPerk()
    {
        //ThisPerk.UpgradeLevel++;
        learnedIMG.enabled = true;
        
    }

}
