using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Transform handle;
    public Material mat;
    public float pointDistance = 0.03f;
    private bool isdraw = false;
    private LineRenderer line;
    private Vector2 lastpos;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&!isdraw)
        {
            isdraw = true;
            line = new GameObject().AddComponent<LineRenderer>();
            line.material = mat;
            line.startWidth = 0.05f;
            line.endWidth = 0.05f;
            line.positionCount = 0;
            lastpos = handle.position;
        }
        if(isdraw)
        {
            if(Vector2.Distance(lastpos,handle.position)>0.03f)
            {
                RealTimeDrawLine(line,handle.position);
                lastpos = handle.position;
            }
        }
        if(Input.GetMouseButtonUp(0)&&isdraw)
        {
            isdraw = false;
            AddEdgeCollider();
        }

    }
    void RealTimeDrawLine(LineRenderer line,Vector2 pos)
    {
        line.positionCount++;
        line.SetPosition(line.positionCount - 1, pos);
    }
    void AddEdgeCollider()
    {
        EdgeCollider2D edge = line.gameObject.AddComponent<EdgeCollider2D>();

        int count = line.positionCount;
        Vector2[] points = new Vector2[count];

        for (int i = 0; i < count; i++)
        {
            points[i] = line.GetPosition(i);
        }

        edge.points = points;
    }
}
