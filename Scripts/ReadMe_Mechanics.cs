using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadMe_Mechanics {

    ///
    /// Galacia Mechanics 
    /// Author - Joseph Rand
    ///

    /// ==Core Mechanics==
    #region Core Mechanics
    /// -Path Mechanics-
    #region Movement Mechanics
    // ============================

    /// AI_Movement Mechanics
    #region AI_Movement Mechanics
    // ---------------------------

    /// MAIN OBJECTIVES :
    // - Be able to handle movement tasks given on parellel frames using courotine: (A_STAR pathing with target, Node paths with path containing nodes)
    // - Be able to switch method of movement with ease : ToAStar(Transform target) , ToPath(Path path)
    // - If stuck (or obstructed from next node) switch to A* and make AI hurry 
    // - Animate based on movement : Direction and speed


    // bool onNodePath
    // bool onStarPath
    // bool pursue
    // bool isRushed

    // PathNode lastNode
    // Transform target

    ///  OBJECTIVE : If Set On PathNode Task
    // - Given a List of Paths to follow
    // - if(!ReachedEnd()) continue path
    // - if(pursue && OnNodePath) Transition from PathNode to A* (target.transform.pos)

    ///  OBJECTIVE : If Set On A* Task
    // - Given the targets pos to pursue
    // - When in range do actions
    // - if(!pursue && OnStarPath) Transition from A* To PathNode(lastnode.pos)


    ///A* PathFinding 
    #region A* PathFinding
    /// CLASS : A_STAR
    // - Finds Objective with shortest path possible
    // - Once reached perform action

    #endregion

    ///PathNode PathFinding
    #region PathNode PathFinding

    /// CLASS : PATH
    // - Has a name for Path
    // - Has a list of PathNodes
    // - Start and End PathNodes
    // - Current Node being persued

    /// CLASS : PATH NODE
    // - Each Node has an index
    // - Each Node has a position
    // - Each Node has a Path Parent

    #endregion

    /// Path Transitioning
    #region Path Transitioning

    /// A* -> PathNode
    // - Go To Last Node (if null -> Nearest Node())
    // - GetNodes index once reached and resume as normal

    /// PathNode -> A*
    // - Assign current Node being pursued to last node
    // - Reach Target and do actions


    #endregion

    // ----------------------------
    #endregion



    // ============================
    #endregion
































    #endregion
































}
