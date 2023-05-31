using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D _edgeCollider2D;
    public LineRenderer _lineRenderer;
    public int collideTime;
    public int triggersToBeErased = 3;


    private void Awake()
    {
        _edgeCollider2D = GetComponent<EdgeCollider2D>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        SetEdgeCollider(_lineRenderer);
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);
        }
    }

    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();
        for (int point = 0; point < lineRenderer.positionCount; point++)
        {
            Vector3 lineRenderPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRenderPoint.x, lineRenderPoint.y));
        }

        _edgeCollider2D.SetPoints(edges);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            collideTime += 1;

            if (collideTime >= triggersToBeErased)
            {
                EraseLevel.Instance.CompleteLevel();
                Debug.Log("You win!");
            }
        }
    }
}