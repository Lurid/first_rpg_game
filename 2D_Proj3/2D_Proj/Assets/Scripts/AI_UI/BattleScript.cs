using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScript : MonoBehaviour {
    public GameObject e_i;
    public GameObject p_i;

    private NPC npc1;
    private NPC npc2;
    public GameObject button_pref;

    public GameObject IndicatorsPanel;
    public GameObject Magic_Panel;
    public GameObject Physical_Panel;
    
    public float W = 0;
    public float H = 0;

    // Use this for initialization
    public void StartBattle (NPC _npc1, NPC _npc2) {
        if (npc1.isEnemy && npc2.isEnemy)
        {

        }
        else
        {
            button_pref.SetActive(true);
            CreateSpellButtons(npc1);
            gameObject.SetActive(true);
            e_i.GetComponent<Image>().sprite = _npc2.sprR.sprite;
        }
    }

    void CreateSpellButtons(NPC npc)
    {
        if (npc.isEnemy == false)
        {
            int c = npc.Spells.Length;
            float h = button_pref.GetComponent<RectTransform>().rect.height;
            for (int i = 0; i < c; i++)
            {
                MagicSpell m_s = npc.Spells[i];
                GameObject n_b = Instantiate(button_pref, Magic_Panel.transform);
                n_b.GetComponent<RectTransform>().localPosition = new Vector3(0, i * h, 0);
                n_b.name = m_s.Name;
                n_b.GetComponent<Button>().enabled = !npc.isEnemy;
                n_b.transform.Find("Text").GetComponent<Text>().text = m_s.Name;
                n_b.GetComponent<Button>().onClick.AddListener(() =>
                {
                    HitEnemy(m_s);
                });
            }
        }
    }




    // Update is called once per frame
    void HitEnemy(MagicSpell m_s)
    {
        transform.GetComponent<NPC>().AttackEnemy(m_s);
        Debug.Log("Player attacked from " + m_s.Name);
    }

    // Update is called once per frame
    void Start () {
        if (IndicatorsPanel != null)
        {
            W = IndicatorsPanel.transform.Find("H").GetComponent<RectTransform>().rect.width;
            H = IndicatorsPanel.transform.Find("M").GetComponent<RectTransform>().rect.height;
        }

        //UpdateIndicators();
    }

    
    public void UpdateIndicators(Health_Indicators h_i)
    {
        if (IndicatorsPanel != null)
        {
            IndicatorsPanel.transform.Find("H").GetComponent<RectTransform>().offsetMax = new Vector3(W * (h_i.Indicators.x / h_i.Max_Indicator.x), 0);
            IndicatorsPanel.transform.Find("M").GetComponent<RectTransform>().offsetMax = new Vector3(W * (h_i.Indicators.y / h_i.Max_Indicator.y), 0);
            IndicatorsPanel.transform.Find("S").GetComponent<RectTransform>().offsetMax = new Vector3(W * (h_i.Indicators.z / h_i.Max_Indicator.z), 0);
        }
    }
}
