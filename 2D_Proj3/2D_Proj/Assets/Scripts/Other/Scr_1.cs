using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Scr_1 : MonoBehaviour {
    public ParticleSystem.MinMaxCurve xx = new ParticleSystem.MinMaxCurve(); //.Linear(0, 1, 1, 0)

    public Rigidbody2D rb_2d;

    void Start () {
        rb_2d = transform.GetComponent<Rigidbody2D>();
        rb_2d.AddForce(new Vector2(10f, 10f), ForceMode2D.Impulse);
        rb_2d.AddTorque(10, ForceMode2D.Force);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
