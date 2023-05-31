using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class Line : MonoBehaviour
{
    public static Line Instance;
    
    [SerializeField] private EdgeCollider2D _edgeCollider2D;
    public LineRenderer _lineRenderer;
    public int collideTime;
    public int dotsNeedConnect;

    private void Awake()
    {
        Instance = this;
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
        if (other.CompareTag("Trigger") && DrawingArea.Instance.CheckDrawingInside())
        {
            collideTime += 1;
            if (collideTime >= dotsNeedConnect)
            {
                GameManager.Instance.CheckWinningCondition();
            }
        }
    }

    public List<Vector3> CreateLinePosList()
    {
        List<Vector3> listPos = new List<Vector3>();
        for (int i = 0; i < _lineRenderer.positionCount; i++)
        {
            listPos.Add(_lineRenderer.GetPosition(i));
        }

        return listPos;
    }
}