using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPerk : Perk {
    public class MultiPerkOne
    {
        public bool Lerned;
        byte NeededLevel;
    }
    public MultiPerk[] MultiPerks;

    // Use this for initialization
    void Start () {
        MultiPerkText.gameObject.SetActive(MultiPerks.Length > 1);
        MultiPerkText.text = "0" + "/" + MultiPerks.Length;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
