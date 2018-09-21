using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour {
    public GameObject parent;
    public GameObject pref;

	// Use this for initialization
	void Start () {
		for(int i = -100; i < 100; i++)
        {
            for (int j = -100; j < 100; j++)
            {
                GameObject new_P = Instantiate(pref);
                new_P.name = "G_" + i + ":"+ j;
                new_P.transform.parent = parent.transform;
                new_P.transform.localPosition = new Vector3(i+0.5f, 0, j + 0.5f);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
