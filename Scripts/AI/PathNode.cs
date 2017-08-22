using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathNode : MonoBehaviour
{
    Path parentPath;
    int index = 0;
    Vector3 pos = new Vector3(0f,0f,-1f);

    public void Start()
    {
        pos = transform.position;
    }

    // CONSTRUCTORS
    public PathNode(float _x, float _y)
    {
        SetPos(_x, _y);
    }
    public PathNode(Vector3 _pos)
    {
        SetPos(_pos);
    }

    // GET/SET POSITION FUNCTIONS
    public Vector3 GetPos()
    {
        return new Vector3(pos.x, pos.y, -1);
    }
    public float GetX()
    {
        return pos.x;
    }
    public float GetY()
    {
        return pos.y;
    }
    public void SetPos(float _x, float _y)
    {
        SetX(_x);
        SetY(_y);
    }
    public void SetPos(Vector3 pos)
    {
        SetX(pos.x);
        SetY(pos.y);
    }
    public void SetX(float _x)
    {
        pos.x = _x;
    }
    public void SetY(float _y)
    {
        pos.y = _y;
    }


    // GET/SET INDEX FUNCTIONS
    public int GetIndex()
    {
        return index;
    }
    public void SetIndex(int i)
    {
        index = i;
    }

    // GET/SET PARENT
    public Path GetParentPath()
    {
        return parentPath;
    }
    public void SetParentPath(Path path)
    {
        parentPath = path;
    }
}

