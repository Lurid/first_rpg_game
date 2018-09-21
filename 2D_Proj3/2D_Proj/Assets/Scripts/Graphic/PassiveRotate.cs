using UnityEngine;

public class PassiveRotate : MonoBehaviour {
    public float Speed = 10f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.GetComponent<RectTransform>().localEulerAngles += new Vector3(0, 0, Speed*Time.deltaTime);
	}
}
