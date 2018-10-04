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
        //thisperk
        lvl.text = (ThisPerk.perkUpgradeLevels[ThisPerk.UpgradeLevel].NeededLevel) + "lvl";
        name.text = ThisPerk.name;
        tree = transform.GetComponentInParent<UpgradeTree>();
        /*Transform y = transform;
        for (int i = 0; i < 3; i++)
        {
            y = y.parent;
            Debug.Log("parent = " + y);
        }*/

        /*Transform y = transform;
        while (y.GetComponentInParent<UpgradeTree>() == null)
        {
            y = y.parent;
            Debug.Log("parent = " + y);
            //
        }*/
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

            ThisPerk.TryLearn();
            if (code != 0)
                tree.Illusion.LearnPerk(code);
        } else
        {
            player.UpgradeDescriptionText(ThisPerk.Description);
            //tree.player.SpellDescriptionTreeUpgradeText.text = Description;
        }
        LastClickTime = Time.time;
    }

    public void LearnThisPerk()
    {
        ThisPerk.UpgradeLevel++;
        learnedIMG.enabled = true;
        Array.ForEach(tree.Illusion.perks, x => { x.CanBeLearned = true; });
    }

}
