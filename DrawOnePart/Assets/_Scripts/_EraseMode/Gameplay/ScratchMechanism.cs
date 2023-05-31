using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchMechanism : MonoBehaviour
{
    public Coroutine erasing;
    public GameObject eraserPrefab;
    public Camera mainCamera;
    public static List<LineRenderer> eraserRenderers = new List<LineRenderer>();
    public Scratch scratchScript;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartErase();
        }

        if (Input.GetMouseButtonUp(0))
        {
            FinishErase();
        }
    }

    private void StartErase()
    {
        if (erasing != null)
        {
            StopCoroutine(erasing);
        }

        erasing = StartCoroutine(EraseWithMouse());
    }

    private void FinishErase()
    {
        if (erasing != null)
            StopCoroutine(erasing);
        eraserRenderers.Clear();
    }

    IEnumerator EraseWithMouse()
    {
        GameObject newGameObject = Instantiate(eraserPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        LineRenderer eraser = newGameObject.GetComponent<LineRenderer>();
        eraserRenderers.Add(eraser);
        eraser.positionCount = 0;
        while (true)
        {
            Vector3 pos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            eraser.positionCount++;
            eraser.SetPosition(eraser.positionCount - 1, pos);
            scratchScript.AssignScreenAsMask();
            yield return null;
        }
    }
}