using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvSize : MonoBehaviour {
    public Vector2 InveSize;
    public Vector2 CompSize;
    public bool[] OpenRows = new bool[4];
    public RectTransform[] BlockRows;
    public GridLayoutGroup glg;

    void Update () {
        CompSize = glg.transform.GetComponent<RectTransform>().rect.size;
        bool WoH = (CompSize.x / InveSize.x) < (CompSize.y / InveSize.y);
        float minSizeOrig = ((WoH) ? (CompSize.x / InveSize.x) : (CompSize.y / InveSize.y));
        float minSize = ((WoH) ? (minSizeOrig - glg.spacing.x) : (minSizeOrig - glg.spacing.y));
        glg.cellSize = new Vector2(minSize, minSize);
        int j = 0;
        for (int i = OpenRows.Length - 1; i >= 0; i--)
        {
            if (OpenRows[i])
            {
                BlockRows[i].gameObject.SetActive(false);
            }
            BlockRows[i].anchoredPosition = new Vector2(0, -((InveSize.y/2) * minSizeOrig) + ((minSize + glg.spacing.y) * j));
            BlockRows[i].sizeDelta = new Vector2(((minSize + glg.spacing.x) * InveSize.x) - glg.spacing.x, minSize);
            j++;
        }
    }
}
