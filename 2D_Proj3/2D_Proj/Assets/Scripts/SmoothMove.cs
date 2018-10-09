using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SmoothMove : MonoBehaviour {
    public AnimationCurve Curve;

    public Vector2 startPos;
    public Vector2 endPos;
    private Vector2 differencePos;
    public Vector2 startSize;
    public Vector2 modifierSize;
    public float LastActionTime = 1000f;
    public bool UoD = true;
    private bool Show = false;
    private bool UoDvector = true;
    public Transform BackgroundObj;
    public float modifierSize2 = 3f;

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
            Set((((UoDvector) ? 1 : 0) - f) * ((UoDvector) ? 1 : -1)); //* ((UoDvector) ? -1 : 1)
        }

        if ((Show == true) && (Time.time > (LastActionTime + MoveTimeInSeconds)))
        {
            if (UoD)
            {
                Set(1);
                UoD = false;
                transform.GetComponent<CanvasGroup>().alpha = 1;
                transform.GetComponent<CanvasGroup>().blocksRaycasts = true;
                transform.GetComponent<RectTransform>().localScale = new Vector3(startSize.x + modifierSize.x, startSize.y + modifierSize.y, 1);
            } else
            {
                Set(0);
                UoD = true;
                transform.GetComponent<CanvasGroup>().alpha = 0;
                transform.GetComponent<CanvasGroup>().blocksRaycasts = false;

                transform.GetComponent<RectTransform>().localScale = new Vector3(startSize.x, startSize.y, 1);
            }
            Show = false;
            UoDvector = !UoDvector;
        }
    }

    void Set(float f)
    {
        Debug.Log("f = " + f);
        transform.GetComponent<RectTransform>().anchoredPosition = startPos + (Curve.Evaluate(f) * differencePos);
        transform.GetComponent<RectTransform>().localScale = new Vector3(startSize.x + (Curve.Evaluate(f) * modifierSize.x), startSize.y + (Curve.Evaluate(f) * modifierSize.y), 1);
        transform.GetComponent<CanvasGroup>().alpha = f;
        BackgroundObj.GetComponent<RectTransform>().anchoredPosition = startPos + (Curve.Evaluate(f) * differencePos);
        BackgroundObj.GetComponent<RectTransform>().localScale = new Vector3((startSize.x + (Curve.Evaluate(f) * modifierSize.x)) * modifierSize2, (startSize.y + (Curve.Evaluate(f) * modifierSize.y)) * modifierSize2, 1);
        BackgroundObj.GetComponent<CanvasGroup>().alpha = 1-f;
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
