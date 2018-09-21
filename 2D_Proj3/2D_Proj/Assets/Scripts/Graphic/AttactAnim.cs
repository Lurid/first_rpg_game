using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttactAnim : MonoBehaviour {
    public bool Enabled;

    public NPC npc;
    
    public float Speed = 3f;
    public float Value = 0f;
    private Material s_p;

    // Use this for initialization
    void Start () {
        s_p = transform.GetComponent<Renderer>().sharedMaterial;
        s_p.SetFloat("_End", s_p.GetFloat("_Start"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Value < 0f)
        {
            Value = 0f;
        }
        if (Value > 1f)
        {
            Value = 1f;
            //npc.AttackPlayer();
            Debug.Log("Enemy! anim (" + Time.time + ")");
            Enabled = false;
        }

        if (Enabled == true)
        {
            if (Value <= 1f)
            {
                Value += Time.deltaTime / Speed;
            }
        }
        else
        {
            if (Value > 0f && Value != 1f) //npc.Battle == false
            {
                Value -= Time.deltaTime / Speed;
            }
        }

        /*if (s_p.GetFloat("_End") > 405)
        {
            s_p.SetFloat("_End", s_p.GetFloat("_Start") + 360f);
        }*/
        s_p.SetFloat("_End", s_p.GetFloat("_Start") + (Value * 360f));
    }
}
