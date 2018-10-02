using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perk : MonoBehaviour {
    public string Name;
    [TextArea(3, 10)] public string Description;
    public byte NeededLevel;
    public byte[] MultiPerk;
    public Perk[] NextPerks;

    public Text lvl;
    public Text name;
    
    void Start () {
        lvl.text = NeededLevel + "lvl";
        name.text = Name;
    }
	
	void Update () {
		
	}
}
