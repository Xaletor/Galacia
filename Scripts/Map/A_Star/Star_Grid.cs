using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_Grid : MonoBehaviour {
    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public Star_Node[,] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;
    float lx, ly;

    public int MaxSize
    {
        get
        {
            return gridSizeX * gridSizeY;
        }
    }
    public void InitializeAStar(int _wx, int _hy, float _lx, float _ly)
    {
        gridWorldSize.x = _wx;
        gridWorldSize.y = _hy;
        lx = _lx - 0.5f;// + 4.5f;
        ly = _ly - 0.5f;// + 4.5f;
        Debug.Log("Centers = (" + _wx + "," + _hy + "," + _lx + "," + _ly + ")");
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Star_Node[gridSizeX, gridSizeY];
        //Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.up * gridWorldSize.y / 2;
        Vector3 worldBottomLeft = new Vector3(lx ,ly,-1f);
        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.up * (y * nodeDiameter + nodeRadius);
                bool walkable = !(Physics2D.OverlapCircle(worldPoint, nodeRadius, unwalkableMask));
                grid[x, y] = new Star_Node(walkable, worldPoint,x,y);
            }
        }
    }

    public List<Star_Node> GetNeighbours(Star_Node node)
    {
        List<Star_Node> neighbors = new List<Star_Node>();
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if(x == 0 && y == 0)
                {
                    continue;
                }
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;

                if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY)
                {
                    neighbors.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighbors;
    }

    public Star_Node NodeFromWorldPoint(Vector3 worldPosition)
    {
        //float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        //float percentY = (worldPosition.y + gridWorldSize.y / 2) / gridWorldSize.y;
        float percentX = (worldPosition.x + Mathf.Abs(lx)) / gridWorldSize.x;
        float percentY = (worldPosition.y + Mathf.Abs(ly))/ gridWorldSize.y;
        //Debug.Log("Percent at : (" + percentX + "," + percentY + ")");
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);
        //Debug.Log("Percent at (clamp) : (" + percentX + "," + percentY + ")");
        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        //Debug.Log("Player at : (" + x + "," + y + ")");
        return grid[x, y];
    }
    

}
