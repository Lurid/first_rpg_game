using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {
    public Health_Indicators h_i;

    public bool isEnemy = true;
    public Vector2Int Pos = new Vector2Int(0, 0);
    public Vector2Int TargetPos = new Vector2Int(0, 0);

    public Item leftHand = new Item();
    public Item rightHand = new Item();

    private GameObject placeAttack;
    public AttactAnim At_An;

    public bool Battle = false;

    public MagicSpell[] Spells; // = new SpellsScript.MagicSpell[]

    public SpriteRenderer sprR;

    public int Karma = 10;

    void Start()
    {
        h_i = transform.GetComponent<Health_Indicators>();
        Pos = new Vector2Int(Mathf.CeilToInt(transform.position.x), Mathf.CeilToInt(transform.position.z));
        if (isEnemy)
        {
            placeAttack = transform.Find("P_A").gameObject;
            At_An = placeAttack.GetComponent<AttactAnim>();
            sprR = transform.Find("lac").Find("Render").GetComponent<SpriteRenderer>();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if ((coll.transform.tag == "NPC"))
        {
            //start battle between NPC
        }
        if ((coll.transform.tag == "Player"))
        {
            At_An.Value = 1;
            At_An.Enabled = true;
            if (coll.GetComponent<NPC>().Karma < 0)
            {
                //start battle with player
            }
        }
    }

    void OnTriggerStay(Collider coll)
    {
        /*if (coll.transform.tag == "Player" && isEnemy == true)
        {
            At_An.Enabled = true;
        }*/
        /*if (coll.transform.tag == "Player")
        {
            coll.transform.GetComponent<PlayerController>().CanMove = false;
        }*/
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.transform.tag == "Player" && isEnemy == true)
        {
            At_An.Enabled = false;
        }
    }

    public void AttackPlayer ()
    {
        if (Battle == false)
        {
            if (!isEnemy)
            {
                At_An.Value = 1f;
                At_An.Enabled = false;
            }
            //GameObject.Find("Canvas").transform.Find("Battle").GetComponent<BattleScript>().StartBattle(this);
            GameObject pl = GameObject.FindWithTag("Player");
            pl.GetComponent<PlayerController>().PlayerTargetPos = Pos;
            pl.transform.GetComponent<PlayerController>().CanMove = false;
            Debug.Log("Enemy! (" + Time.time + ")");
            Battle = true;
        }
    }

    public void AttackEnemy(MagicSpell m_s)
    {
        //h_i.Indicators += npc_Enemy.GetComponent<Health_Indicators>().TakeHit(m_s);
        //h_i.UpdateIndicators();
    }
}
