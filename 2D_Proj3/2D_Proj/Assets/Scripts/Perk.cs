using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perk : MonoBehaviour {
    public bool learned = false;
    public bool CanBeLearned = false;
    public string Name;
    [TextArea(3, 10)] public string Description;
    public byte NeededLevel;
    public Perk[] NextPerks;

    public Text lvl;
    public Text name;
    public Text MultiPerkText;
    public UpgradeTree tree;
    public Image learnedIMG;

    void Start () {
        lvl.text = (NeededLevel) + "lvl";
        name.text = Name;
        tree = transform.GetComponentInParent<UpgradeTree>();
        CanBeLearned = NeededLevel == 0;
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
        tree.Bottom.text = Description;

    }

    public void Exit()
    {
        tree.Bottom.text = "";
    }

    public void Click()
    {
        transform.GetComponentInParent<Player>().TryLernPerk(this);
    }

    public void LearnThisPerk()
    {
        learned = true;
        learnedIMG.enabled = true;
        for(int i = 0; i < NextPerks.Length; i++)
        {
            NextPerks[i].CanBeLearned = true;
        }
    }

}
