using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DunGen : MonoBehaviour {
    public GameObject a_Star;
    public int totalNonDeadEndRooms;

    [Range(0, 100)]
    public int mobChance;

    [Range(0, 100)]
    public int chestChance;

    public GameObject startPrefab;
    public GameObject endPrefab;

    [Header("4 Way Passages")]
    public List<GameObject> passage_IV;

    [Header("2 Way Passages")]
    public List<GameObject> passage_II_RL;
    public List<GameObject> passage_II_UD;

    [Header("90 Degree Turns")]
    public List<GameObject> d_R_turns;
    public List<GameObject> d_L_turns;
    public List<GameObject> u_R_turns;
    public List<GameObject> u_L_turns;

    [Header("DeadEnds")]
    public List<GameObject> right_ends;
    public List<GameObject> left_ends;
    public List<GameObject> down_ends;
    public List<GameObject> up_ends;

    public List<DunGenRoom> SpawnedRooms = new List<DunGenRoom>();

    int x;
    int y;

    int currentDirection;

    int lowestPoint;
    int highestPoint;
    int leftMostPoint;
    int rightMostPoint;

    DunGenRoom selectedRoom;
    DunGenRoom lastRoom;

    bool complete;
    bool spawned;
    int debugTimer = 0;
    float delay = 1f;

    public void Awake()
    {
        InitializeDungeonGenerator();
    }

    void InitializeDungeonGenerator()
    {
        spawned = false;
        complete = false;
        x = 0;
        y = 0; 
    }

    public void Update()
    {
        if( complete && !spawned)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                SpawnMonsters();
                SpawnChests();
                spawned = true;
            }
        }
        if (!complete)
        {
            Generate();
            complete = CheckIfComplete();
            if (complete)
            {
                SpawnPortals();
                var mapx = Mathf.Abs(rightMostPoint) + Mathf.Abs(leftMostPoint) + 10;
                var mapy = Mathf.Abs(highestPoint) + Mathf.Abs(lowestPoint) + 10;
                var midx = leftMostPoint;
                var midy = lowestPoint;
                a_Star.GetComponent<Star_Grid>().InitializeAStar(mapx,mapy,midx,midy);
            }
        }
    }

    void SpawnMonsters()
    {
        int mobcount = 0;
        Monster_Database mobData = GameObject.Find("Database_Monster").GetComponent<Monster_Database>();
        GameObject[] mobSpawns = GameObject.FindGameObjectsWithTag("Spawn_Point");
        foreach(GameObject go in mobSpawns)
        {
            int i = Random.Range(0, 100 + 1);
            if(i < mobChance)
            {
                GameObject mobClone = Instantiate(mobData.GetMonster(Random.Range(0,2)),GameObject.Find("Monsters").transform) as GameObject;
                mobClone.transform.position = go.transform.position;
                mobcount++;
            }
        }
        Debug.Log(mobcount + " monsters have spawned.");
    }

    void SpawnChests()
    {
        int chestCount = 0;
        Chest_Database chestData = GameObject.Find("Database_Chest").GetComponent<Chest_Database>();
        GameObject[] chestSpawns = GameObject.FindGameObjectsWithTag("Chest_Point");
        foreach (GameObject go in chestSpawns)
        {
            int i = Random.Range(0, 100 + 1);
            if (i < chestChance)
            {
                GameObject chestClone = Instantiate(chestData.GetChest(Random.Range(0, 3)), GameObject.Find("Chests").transform) as GameObject;
                chestClone.transform.position = new Vector2(go.transform.position.x,go.transform.position.y);
                chestCount++;
            }
        }
        Debug.Log(chestCount + " chests have spawned.");
    }

    void SpawnPortals()
    {
        Vector3 origin = new Vector3(0, 0, -4);
        Vector3 p_Offset = new Vector3(4.5f,4.5f,-0.01f);
        GameObject closestRoom = null;
        GameObject[] endRooms;
        endRooms = GameObject.FindGameObjectsWithTag("End_Room");
        GameObject startPortal = Instantiate(startPrefab, SpawnedRooms[0].transform) as GameObject;
        startPortal.transform.position = p_Offset;

        foreach(GameObject go in endRooms)
        {
            if(closestRoom == null && go != SpawnedRooms[0])
            {
                closestRoom = go;
                continue;
            }
            else
            {
                if(Vector2.Distance(go.transform.position,origin) > Vector2.Distance(closestRoom.transform.position, origin) && go != SpawnedRooms[0])
                {
                    closestRoom = go;
                }
            }
        }

        GameObject endPortal = Instantiate(endPrefab, closestRoom.transform) as GameObject;
        endPortal.transform.position = new Vector2(endPortal.transform.position.x + p_Offset.x, endPortal.transform.position.y + p_Offset.y);

        for (int i = 0; i < closestRoom.transform.childCount; i++)
        {
            if (closestRoom.transform.GetChild(i).tag == "Chest_Point")
            {
                Destroy(closestRoom.transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < closestRoom.transform.childCount; i++)
        {
            if (closestRoom.transform.GetChild(i).tag == "Spawn_Point")
            {
                Destroy(closestRoom.transform.GetChild(i).gameObject);
            }
        }
        for (int i = 0; i < SpawnedRooms[0].transform.childCount; i++)
        {
            if (SpawnedRooms[0].transform.GetChild(i).tag == "Chest_Point")
            {
                Destroy(SpawnedRooms[0].transform.GetChild(i).gameObject);
            }
        }

        for (int i = 0; i < SpawnedRooms[0].transform.childCount; i++)
        {
            if (SpawnedRooms[0].transform.GetChild(i).tag == "Spawn_Point")
            {
                Destroy(SpawnedRooms[0].transform.GetChild(i).gameObject);
            }
        }

    }

    bool CheckIfComplete()
    {
        foreach(DunGenRoom r in SpawnedRooms)
        {
            if (!r.locked)
            {
                return false;
            }
        }
        Debug.Log("MapGenerated");
        return true;
    }

    void Generate()
    {
        debugTimer++;
        if (SpawnedRooms.Count == 0)
        {
            currentDirection = GetRandomDirection();
            GameObject start = GetEndRoom(Random.Range(0,4));
            Spawn(start, currentDirection);
        }
        else if(SpawnedRooms.Count < totalNonDeadEndRooms && SpawnedRooms.Count != 0 && debugTimer < 25)
        {
            currentDirection = GetRandomDirection();   
            GameObject gRoom = GetRandomRoom();
            selectedRoom = gRoom.GetComponent<DunGenRoom>();
            if (Linkable(lastRoom, selectedRoom, currentDirection))
            {
                if (!RoomInWayOfDirection(currentDirection))
                {
                    Spawn(gRoom,currentDirection);
                }
            }
        }  
        else
        {
            FinishRooms();      
        }
    }

    void FinishRooms()
    {
        for(int i = 0; i < SpawnedRooms.Count; i++)
        {
            if (!SpawnedRooms[i].locked)
            {
                lastRoom = SpawnedRooms[i];
                x = lastRoom.x;
                y = lastRoom.y;
                if (!SpawnedRooms[i].rightOcc)
                {
                    currentDirection = 0;
                    GameObject grm = GetEndRoom(0);
                    selectedRoom = grm.GetComponent<DunGenRoom>();
                    if (Linkable(lastRoom, selectedRoom, currentDirection))
                    {
                        if (!RoomInWayOfDirection(currentDirection))
                        {
                            Spawn(grm, currentDirection);
                        }
                        else
                        {
                            SpawnedRooms[i].rightOcc = true;
                        }
                    }
                }
                if (!SpawnedRooms[i].leftOcc)
                {
                    currentDirection = 1;
                    GameObject grm = GetEndRoom(1);
                    selectedRoom = grm.GetComponent<DunGenRoom>();
                    if (Linkable(lastRoom, selectedRoom, currentDirection))
                    {
                        if (!RoomInWayOfDirection(currentDirection))
                        {
                            Spawn(grm, currentDirection);
                        }
                        else
                        {
                            SpawnedRooms[i].leftOcc = true;
                        }
                    }
                }
                if (!SpawnedRooms[i].downOcc)
                {
                    currentDirection = 2;
                    GameObject grm = GetEndRoom(2);
                    selectedRoom = grm.GetComponent<DunGenRoom>();
                    if (Linkable(lastRoom, selectedRoom, currentDirection))
                    {
                        if (!RoomInWayOfDirection(currentDirection))
                        {
                            Spawn(grm, currentDirection);
                        }
                        else
                        {
                            SpawnedRooms[i].downOcc = true;
                        }
                    }
                }
                if (!SpawnedRooms[i].upOcc)
                {
                    currentDirection = 3;
                    GameObject grm = GetEndRoom(3);
                    selectedRoom = grm.GetComponent<DunGenRoom>();
                    if (Linkable(lastRoom, selectedRoom, currentDirection))
                    {
                        if (!RoomInWayOfDirection(currentDirection))
                        {
                            Spawn(grm, currentDirection);
                        }
                        else
                        {
                            SpawnedRooms[i].upOcc = true;
                        }
                    }
                }
                complete = CheckIfComplete();
            }
        }
    }
    // Pathstuff here
    void Spawn(GameObject gRoom, int dir)
    {
        if (dir == 0)
        {
            GameObject roomClone = Instantiate(gRoom, transform) as GameObject;
            var r = roomClone.GetComponent<DunGenRoom>();
            if (lastRoom == null)
            {

            }
            else
            {
                r.x = x + 1;
                r.y = y;
                lastRoom.rightOcc = true;
                r.leftOcc = true;
                lastRoom.connectedRightRoom = r;
                r.connectedLeftRoom = lastRoom;
            }
            roomClone.transform.position = new Vector3(r.x * 10, r.y * 10, -2);
            CheckForFurthestPoint(roomClone.transform.position);
            SpawnedRooms.Add(r);         
            lastRoom = r;
        }
        else if (dir == 1)
        {
            GameObject roomClone = Instantiate(gRoom, transform) as GameObject;
            var r = roomClone.GetComponent<DunGenRoom>();
            if (lastRoom == null)
            {

            }
            else
            {
                r.x = x - 1;
                r.y = y;
                lastRoom.leftOcc = true;
                r.rightOcc = true;
                lastRoom.connectedLeftRoom = r;
                r.connectedRightRoom = lastRoom;
            }
            roomClone.transform.position = new Vector3(r.x * 10, r.y * 10, -2);
            CheckForFurthestPoint(roomClone.transform.position);
            SpawnedRooms.Add(r);
            lastRoom = r;
        }
        else if (dir == 2)
        {
            GameObject roomClone = Instantiate(gRoom, transform) as GameObject;
            var r = roomClone.GetComponent<DunGenRoom>();
            if (lastRoom == null)
            {

            }
            else
            {
                r.x = x;
                r.y = y - 1;
                lastRoom.downOcc = true;
                r.upOcc = true;
                lastRoom.connectedDownRoom = r;
                r.connectedUpRoom = lastRoom;
            }
            roomClone.transform.position = new Vector3(r.x * 10, r.y * 10, -2);
            CheckForFurthestPoint(roomClone.transform.position);
            SpawnedRooms.Add(r);
            lastRoom = r;
        }
        else if (dir == 3)
        {
            GameObject roomClone = Instantiate(gRoom, transform) as GameObject;
            var r = roomClone.GetComponent<DunGenRoom>();
            if (lastRoom == null)
            {

            }
            else
            {
                r.x = x;
                r.y = y + 1;
                lastRoom.upOcc = true;
                r.downOcc = true;
                lastRoom.connectedUpRoom = r;
                r.connectedDownRoom = lastRoom;
            }
            roomClone.transform.position = new Vector3(r.x * 10, r.y * 10, -2);
            CheckForFurthestPoint(roomClone.transform.position);
            SpawnedRooms.Add(r);
            lastRoom = r;
        }
        x = lastRoom.x;
        y = lastRoom.y;
        debugTimer = 0;
    }

    public void CheckForFurthestPoint(Vector3 pos)
    {
        if (pos.x > rightMostPoint)
        {
            rightMostPoint = (int)pos.x;
        }
        if (pos.x < leftMostPoint)
        {
            leftMostPoint = (int)pos.x;
        }
        if (pos.y < lowestPoint)
        {
            lowestPoint = (int)pos.y;
        }
        if (pos.y > highestPoint)
        {
            highestPoint = (int)pos.y;
        }

    }

    bool Linkable(DunGenRoom l, DunGenRoom c, int dir)
    {
        if(dir == 0)
        {
            if(l.rightOcc == false && c.leftOcc == false)
            {
                return true;
            }
        }
        else if (dir == 1)
        {
            if (l.leftOcc == false && c.rightOcc == false)
            {
                return true;
            }
        }
        else if (dir == 2)
        {
            if (l.downOcc == false && c.upOcc == false)
            {
                return true;
            }
        }
        else if (dir == 3)
        {
            if (l.upOcc == false && c.downOcc == false)
            {
                return true;
            }
        }
        return false;
    }

    bool RoomInWayOfDirection(int j)
    {
        foreach(DunGenRoom rm in SpawnedRooms)
        {
           if(j == 0)
            {
                if(rm.x == x + 1 && rm.y == y)
                {
                    return true;
                }
            }
            else if (j == 1)
            {
                if(rm.x == x - 1 && rm.y == y)
                {
                    return true;
                }
            }
            else if (j == 2)
            {
                if (rm.x == x && rm.y == y - 1)
                {
                    return true;
                }
            }
            else if (j == 3)
            {
                if (rm.x == x && rm.y == y + 1)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void SetGenLocation(int _x, int _y)
    {
        x = _x;
        y = _y;
    }

    public int GetRandomDirection()
    {
        return Random.Range(0, 4);
    }
    public int GetRandomRoomType(bool limit = false)
    {
        if (!limit)
        {
            return Random.Range(0, 7);
        }
        else
        {
            return Random.Range(7, 11);
        }
    }
    public GameObject GetRandomRoom(bool limit = false)
    {
        DunGenRoom.RoomType type = (DunGenRoom.RoomType)GetRandomRoomType(limit);

        if (type == DunGenRoom.RoomType.End_D)
        {
            return GetEndRoom(2);
        }
        else if (type == DunGenRoom.RoomType.End_L)
        {
            return GetEndRoom(1);
        }
        else if (type == DunGenRoom.RoomType.End_R)
        {
            return GetEndRoom(0);
        }
        else if (type == DunGenRoom.RoomType.End_U)
        {
            return GetEndRoom(3);
        }
        else if (type == DunGenRoom.RoomType.IIW_LR)
        {
            return GetPassage(0);
        }
        else if (type == DunGenRoom.RoomType.IIW_UD)
        {
            return GetPassage(1);
        }
        else if (type == DunGenRoom.RoomType.IVW)
        {
            return GetPassage(2);
        }
        else if (type == DunGenRoom.RoomType.Turn_DL)
        {
            return GetTurnRoom(1);
        }
        else if (type == DunGenRoom.RoomType.Turn_DR)
        {
            return GetTurnRoom(0);
        }
        else if (type == DunGenRoom.RoomType.Turn_UL)
        {
            return GetTurnRoom(3);
        }
        else
        {
            return GetTurnRoom(2);
        }
    }

    // Get A Turn Room
    GameObject GetEndRoom(int x = 0)
    {
        if (x == 0)  // Right Down
        {
            return GetRightEnd(Random.Range(0, right_ends.Count));
        }
        else if (x == 1)    // Left Down
        {
            return GetLeftEnd(Random.Range(0, left_ends.Count));
        }
        else if (x == 2)    // Right Up
        {
            return GetDownEnd(Random.Range(0, down_ends.Count));
        }
        else                // Left Up
        {
            return GetUpEnd(Random.Range(0, up_ends.Count));
        }
    }
    GameObject GetRightEnd(int x)
    {
        return right_ends[x];
    }
    GameObject GetLeftEnd(int x)
    {
        return left_ends[x];
    }
    GameObject GetDownEnd(int x)
    {
        return down_ends[x];
    }
    GameObject GetUpEnd(int x)
    {
        return up_ends[x];
    }
    GameObject GetPassage(int x = 0)
    {
        if (x == 0)
        {
            return GetRLPassage(Random.Range(0, passage_II_RL.Count));
        }
        else if (x == 1)
        {
            return GetDUPassage(Random.Range(0, passage_II_UD.Count));
        }
        else
        {
            return GetIVPassage(Random.Range(0, passage_IV.Count));
        }
    }
    GameObject GetRLPassage(int x)
    {
        return passage_II_RL[x];
    }
    GameObject GetDUPassage(int x)
    {
        return passage_II_UD[x];
    }
    GameObject GetIVPassage(int x)
    {
        return passage_IV[x];
    }
    // Get A Turn Room
    GameObject GetTurnRoom(int x = 0)
    {
        if (x == 0)  // Right Down
        {
            return GetRightDownTurn(Random.Range(0, d_R_turns.Count));
        }
        else if (x == 1)    // Left Down
        {
            return GetLeftDownTurn(Random.Range(0, d_L_turns.Count));
        }
        else if (x == 2)    // Right Up
        {
            return GetRightUpTurn(Random.Range(0, u_R_turns.Count));
        }
        else                // Left Up
        {
            return GetLeftUpTurn(Random.Range(0, u_L_turns.Count));
        }
    }
    GameObject GetRightDownTurn(int x)
    {
        return d_R_turns[x];
    }
    GameObject GetLeftDownTurn(int x)
    {
        return d_L_turns[x];
    }
    GameObject GetRightUpTurn(int x)
    {
        return u_R_turns[x];
    }
    GameObject GetLeftUpTurn(int x)
    {
        return u_L_turns[x];
    }



}
