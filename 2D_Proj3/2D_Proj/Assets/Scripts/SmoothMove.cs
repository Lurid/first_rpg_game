using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SmoothMove : MonoBehaviour {
    public AnimationCurve positionCurve;
    public AnimationCurve sizeCurve;

    public Vector2 startPos;
    public Vector2 endPos;
    private Vector2 differencePos;
    public Vector2 sizeModificator = Vector2.one;
    public float LastActionTime = 1000f;
    public bool UoD = true;
    private bool Show = false;
    private bool UoDvector = true;

    public float MoveTimeInSeconds = 4f;

    // Use this for initialization
    void Start () {
        differencePos = endPos - startPos;
        Debug.Log("differencePos = " + differencePos);
    }
	
	// Update is called once per frame
	void Update () {
        if (Show)
        {
            float f = (Time.time - LastActionTime) / MoveTimeInSeconds;
            Set(((UoDvector) ? 1 : 0) - f * ((UoDvector) ? -1 : 1));
        }

        if ((Show == true) && (Time.time > (LastActionTime + MoveTimeInSeconds)))
        {
            if (UoD)
            {
                Set(1);
                UoD = false;
            } else
            {
                Set(0);
                UoD = true;
            }
            Show = false;
            UoDvector = !UoDvector;
        }
    }

    void Set(float f)
    {
        transform.GetComponent<RectTransform>().anchoredPosition = startPos + (positionCurve.Evaluate(f) * differencePos);
        transform.GetComponent<RectTransform>().localScale = new Vector3((sizeCurve.Evaluate(f) * sizeModificator.x), (sizeCurve.Evaluate(f) * sizeModificator.y), 1);
    }

    public void ShowIt()
    {
        Show = true;
        LastActionTime = Time.time;
        UoDvector = true;
    }

    public void HideIt()
    {
        Show = true;
        LastActionTime = Time.time;
        UoDvector = false;
    }

    public void Click()
    {
        if (Time.time - LastActionTime < MoveTimeInSeconds)
        {
            UoDvector = !UoDvector;
            LastActionTime = 2f * Time.time - LastActionTime - MoveTimeInSeconds; //Time.time - (LastActionTime + MoveTimeInSeconds - Time.time)
            UoD = !UoD;
            Show = true;
        }
        else
        {
            if (UoD)
                HideIt();
            else
                ShowIt();
        }
    }
}
