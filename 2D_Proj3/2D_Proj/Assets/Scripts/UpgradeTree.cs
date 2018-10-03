using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTree : MonoBehaviour {
    public string SkillName;
    public skillType SkillType;
    public Text Upper;
    public Text Bottom;

    public void UpgradeSkillPointsText()
    {
        Upper.text = "Уровень навыка "+ SkillName + ": " + transform.GetComponentInParent<Player> ();
    }
}
