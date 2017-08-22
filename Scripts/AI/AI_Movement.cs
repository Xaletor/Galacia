using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AI_Movement : MonoBehaviour {


    public float aggroRange;
    public List<Path> paths;
    int pathIndex = 0;
    public int activeNodeIndex = 0;
    public PathNode activeNode;
    AudioSource aS;
    SoundManager sM;
    Animator animator;
    bool[] playing = new bool[5];
    bool started = false;
    bool pathComplete = false;
    bool pathInProgress = false;
    
    public enum Direction
    {
        Right,
        Left,
        Down,
        Up,
        None
    }

    public float speed;

    public void Start()
    {
        pathIndex = -1;
        for (int i = 0; i < 5; i++)
        {
            playing[i] = false;
        }
        animator = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
        sM = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        AnimateMovement(Direction.None);
        started = true;
    }

    public void GetWalkSound()
    {
        aS.volume = 0.4f;
        aS.pitch = Random.Range(0.80f, 1.50f);
        aS.PlayOneShot(sM.GetPeopleClip(0));
    }

    public void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -1 + (transform.position.y/20000f));

        if ((started && !pathInProgress))
        {
            pathIndex++;
            pathInProgress = true;
            pathComplete = false;

            if (paths.Count > 1)
            {
                if(pathIndex >= paths.Count)
                {
                    pathIndex = 0;
                }
                StartCoroutine(FollowPath(paths[pathIndex]));
            }
            else if(paths.Count == 1)
            {
                StartCoroutine(FollowPath(paths[0]));
            }
        }
        if(activeNode == null)
        {
            //Debug.Log("Stopped Moving");
            AnimateMovement(Direction.None);
        }
    }


    // Move to the Path passed
    IEnumerator FollowPath(Path path)
    {
        if (tag != "Monster")
        {
            //Debug.Log("Follow Path Called");
            activeNode = path.GetStartNode();
            while (!pathComplete)
            {
                StartCoroutine(MoveToTarget(activeNode.GetPos().x, activeNode.GetPos().y));
                yield return null;
            }

            pathInProgress = false;
        }
        else
        {
            var p = GameObject.Find("Player");
            while (Vector3.Distance(transform.position, p.transform.position) < aggroRange)
            {
                StartCoroutine(MoveToTarget(p.transform.position.x, p.transform.position.y));
                yield return null;
            }
        }
    }

    public void NextNode()
    {
        //Debug.Log("Next Node Called");
        if (activeNode.GetIndex() + 1 < activeNode.GetParentPath().nodes.Count)
        {
            activeNode = activeNode.GetParentPath().nodes[activeNode.GetIndex() + 1];
            activeNodeIndex = activeNode.GetIndex();
        }
        else
        {
            pathComplete = true;
            AnimateMovement(Direction.None);
            activeNode = null;
        }
    }

    public void SetPlaying(int i)
    {
        for(int x = 0; x < 5; x++)
        {
            if (i != x)
            {
                playing[x] = false;
            }
            else if( i == x)
            {
                playing[x] = true;
            }
        }
    }

    public void AnimateMovement(Direction direction)
    {
        if(direction == Direction.None && !playing[0])
        {
            animator.SetInteger("Direction",4);
            animator.speed = speed;
            SetPlaying(0);
        }
        else if (direction == Direction.Right && !playing[1])
        {
            animator.SetInteger("Direction", 0);
            animator.speed = speed;
            SetPlaying(1);
        }
        else if (direction == Direction.Left && !playing[2])
        {
            animator.SetInteger("Direction", 1);
            animator.speed = speed;
            SetPlaying(2);
        }
        else if (direction == Direction.Down && !playing[3])
        {
            animator.SetInteger("Direction", 2);
            animator.speed = speed;
            SetPlaying(3);
        }
        else if (direction == Direction.Up && !playing[4])
        {
            animator.SetInteger("Direction", 3);
            animator.speed = speed;
            SetPlaying(4);
        }

    }

        // Move to Path Node passed
        IEnumerator MoveToTarget(float tx, float ty)
    {
        if (tag != "Monster")
        {
            //Debug.Log("Move To Node Called");
            float step = speed * Time.deltaTime;
            if (tag != "Monster")
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(tx, ty, transform.position.z), step);
            }
            yield return null;

            float x = Mathf.Abs(transform.position.x - tx);
            float y = Mathf.Abs(transform.position.y - ty);

            if (x + y < 0.1f && tag != "Monster")
            {
                NextNode();
            }
            LookAtTarget(tx, ty, x, y);

            //Debug.Log(x + " " + y);
        }
    }

    void LookAtTarget(float tx, float ty,float x,float y)
    {
        if (transform.position.x < tx && x > y)          // Target pos is to the right of us
        {
            AnimateMovement(Direction.Right);
        }
        else if (transform.position.x > tx && x > y)     // Target pos is to the left of us
        {
            AnimateMovement(Direction.Left);
        }
        else if (transform.position.y > ty && y > x)     // Target pos is below us
        {
            AnimateMovement(Direction.Down);
        }
        else if (transform.position.y < ty && y > x)     // Targer pos is above us
        {
            AnimateMovement(Direction.Up);
        }
        else
        {
            AnimateMovement(Direction.None);
        }
    }

    public void Move(Transform t, Direction direction)
    {
        if (tag != "Monster")
        {
            if (direction == Direction.Right)
            {
                t.Translate(-speed * Time.deltaTime, 0, 0);
            }
            else if (direction == Direction.Left)
            {
                t.Translate(speed * Time.deltaTime, 0, 0);
            }
            else if (direction == Direction.Down)
            {
                t.Translate(0, -speed * Time.deltaTime, 0);
            }
            else if (direction == Direction.Up)
            {
                t.Translate(0, speed * Time.deltaTime, 0);
            }
            else
            {
                // Dont Move, Animate Still
            }
        }
    }

}
