using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Perk : MonoBehaviour {
    public uint code;

    private pperk ThisPerk;

    public Text lvl;
    public Text name;
    public UpgradeTree tree;
    public Image learnedIMG;
    public Player player;

    private float LastClickTime;

    void Start () {
        if (ThisPerk != null) {
            lvl.text = (ThisPerk.perkUpgradeLevel.NeededLevel) + "lvl";
            name.text = ThisPerk.name;
            tree = transform.GetComponentInParent<UpgradeTree>();
        }
        player = GetComponentInParent<Player>();
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
            player.UpgradeDescriptionText(ThisPerk);
        }
        LastClickTime = Time.time;
    }

    public void LearnThisPerk()
    {
        //ThisPerk.UpgradeLevel++;
        learnedIMG.enabled = true;
        
    }

}
