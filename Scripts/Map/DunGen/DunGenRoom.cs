using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DunGenRoom : MonoBehaviour {

    public int x;
    public int y;

    public RoomType roomType;

    public List<PathNode> RightToLeft;
    public List<PathNode> RightToDown;
    public List<PathNode> RightToUp;

    public List<PathNode> LeftToRight;
    public List<PathNode> LeftToDown;
    public List<PathNode> LeftToUp;

    public List<PathNode> DownToRight;
    public List<PathNode> DownToLeft;
    public List<PathNode> DownToUp;

    public List<PathNode> UpToRight;
    public List<PathNode> UpToLeft;
    public List<PathNode> UpToDown;


    public bool rightOcc;
    public bool leftOcc;
    public bool downOcc;
    public bool upOcc;
    public bool locked;

    public DunGenRoom connectedRightRoom;
    public DunGenRoom connectedLeftRoom;
    public DunGenRoom connectedDownRoom;
    public DunGenRoom connectedUpRoom;


    public void Update()
    {
        if(rightOcc && leftOcc && downOcc && upOcc)
        {
            locked = true;
        }
    }

    public enum RoomType
    {
        IVW,
        IIW_LR,
        IIW_UD,
        Turn_DR,
        Turn_DL,
        Turn_UR,
        Turn_UL,
        End_R,
        End_L,
        End_D,
        End_U
    }

    public bool GetOppositeOcc(int i)
    {
        if (i == 0)
        {
            return leftOcc;
        }
        else if (i == 1)
        {
            return rightOcc;
        }
        else if (i == 2)
        {
            return upOcc;
        }
        else
        {
            return downOcc;
        }
    }

    public bool GetOcc(int i)
    {
        if (i == 0)
        {
            return rightOcc;
        }
        else if (i == 1)
        {
            return leftOcc;
        }
        else if (i == 2)
        {
            return downOcc;
        }
        else
        {
            return upOcc;
        }
    }


}
