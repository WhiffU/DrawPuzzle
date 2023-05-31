using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingArea : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public static DrawingArea Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public bool CheckDrawingInside()
    {
        bool isDrawingInside = true;
        for (int i = 0; i < Line.Instance.CreateLinePosList().Count; i++)
        {
            if (!boxCollider.bounds.Contains(Line.Instance._lineRenderer.GetPosition(i)))
            {
                Line.Instance.CreateLinePosList().Add(Line.Instance._lineRenderer.GetPosition(i));
                isDrawingInside = false;
            }
        }

        return isDrawingInside;
    }
}