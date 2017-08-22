using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

    public string pathName;
    public List<PathNode> nodes;
    PathNode startNode;
    PathNode endNode;

    public void Start()
    {
        startNode = nodes[0];
        endNode = nodes[0];

        for(int i = 0; i < nodes.Count; i++)
        {
            nodes[i].SetParentPath(this);
            nodes[i].SetIndex(i);
        }
    }

    public PathNode GetStartNode()
    {
        return startNode;
    }

    public PathNode GetEndNode()
    {
        return endNode;
    }

}
