using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    AudioSource aS;
    SoundManager sM;
    Animator animator;
    bool[] playing = new bool[5];
    public float speed = 0;
    public bool attacking = false;
    public bool casting = false;
    float castTimer = 0f;
    float walkTimer = 0f;
    float hitTimer = 0.5f;
    Direction lastDirection;
    public enum Direction
    {
        Right,
        Left,
        Down,
        Up,
        None,
    }
    float speedmod;
    public void Start()
    {
        speedmod = speed * 2;
        animator = GetComponent<Animator>();
        aS = GetComponent<AudioSource>();
        sM = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        lastDirection = Direction.None;
    }

    public void FixedUpdate()
    {
        hitTimer -= Time.deltaTime;
        walkTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && (!attacking && !Inventory_Display_UI.isOpen))
        {
            if (hitTimer <= 0)
            {
                StartCoroutine(Attack());
            }
        }
        if (!attacking && !casting && (!Input.GetMouseButton(0) || walkTimer <= 0 || hitTimer > 0))
        {
            animator.speed = 1;
            Move();

        }
        else if (attacking)
        {
            /*
            animator.speed = (speedmod/2) * 3;
            if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                attacking = false;
                aS.volume = 1f;
                animator.SetBool("attacking", false);
                //Debug.Log("FINISHED ATTACKING!"); 
            }
            */
        }
        if (casting)
        {
            castTimer -= Time.deltaTime;
            if(castTimer <= 0)
            {
                casting = false;
            }
        }
    }

    public void GetWalkSound()
    {
        aS.volume = 0.4f;
        aS.pitch = Random.Range(0.80f, 1.20f);
        aS.PlayOneShot(sM.GetPeopleClip(0));
    }

    public IEnumerator Attack()
    {
        attacking = true;
        animator.SetBool("walking", false);
        AnimateAttack((Direction)GetMouseQuadrant());
        aS.pitch = Random.Range(0.80f, 1.20f);
        aS.volume = 0.3f;
        aS.PlayOneShot(sM.GetAttackClip(0));
        animator.speed = GetAnimationSpeed();
        //Debug.Log("ATTACKING!");
        yield return new WaitForSeconds(GetAttackSpeed());
        attacking = false;
        animator.SetBool("attacking", false);
        hitTimer = GetAttackSpeed();
        walkTimer = 0.1f;
    }
    public float GetAnimationSpeed()
    {
        var pS = GetComponent<Player_Stats>();
        float pSpd = pS.speed;
        float pLvl = pS.playerLevel;
        float mod = (pSpd / (pLvl * 3f));
        if (mod <= 1f)
        {
            return 2f;
        }
        else if (mod > 1f && mod <= 2f)
        {
            return 2.3f;
        }
        else if (mod > 2f && mod <= 3f)
        {
            return 2.5f;
        }
        else if (mod > 3f && mod <= 4f)
        {
            return 2.7f;
        }
        else if (mod > 4f)
        {
            return 3f;
        }
        return 0.5f;
    }
    public float GetAttackSpeed()
    {
       var pS = GetComponent<Player_Stats>();
        float pSpd = pS.speed;
        float pLvl = pS.playerLevel;
        float mod = (pSpd / (pLvl * 3f));
        if(mod <= 1f)
        {
            return 0.5f;
        }
        else if (mod > 1f && mod <= 2f)
        {
            return 0.4f;
        }
        else if (mod > 2f && mod <= 3f)
        {
            return 0.3f;
        }
        else if (mod > 3f && mod <= 4f)
        {
            return 0.2f;
        }
        else if (mod > 4f)
        {
            return 0.1f;
        }
        return 0.5f;

    }
    public void CastAttack()
    {
        castTimer = 0.25f;
        casting = true;
        aS.pitch = Random.Range(0.80f, 1.20f);
        aS.volume = 0.3f;
        //aS.PlayOneShot(sM.GetAttackClip(1));
        //Debug.Log("ATTACKING!");
        AnimateCasting((Direction)GetMouseQuadrant());
        //animator.SetBool("casting", attacking);
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftShift) && GetComponent<Player_Stats>().currentEP >= 0)
        {
            speed = 2;   
        }
        else
        {
            speed = 1;
        }
        animator.speed = speed;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        animator.SetBool("walking", true);
        if (x < 0.1f && y < 0.1f && x > -0.1f && y > -0.1f)
        {
            animator.SetBool("walking", false);
        }
        if (animator.GetBool("walking"))
        {
                animator.SetFloat("Input_X", x);
                animator.SetFloat("Input_Y", y);  
            if(speed == 2)
            {
                GetComponent<Player_Stats>().currentEP -= (Time.deltaTime * 5);
            }  
        }
        x = x * (speed * 2) * Time.deltaTime;
        y = y * (speed * 2) * Time.deltaTime;
        transform.Translate(new Vector3(x, y, 0));
        transform.position = new Vector3(transform.position.x, transform.position.y, -1 + (transform.position.y / 20000f));
        //SetDirection(x, y);
    }

    public void SetDirection(float x, float y)
    {
        float abX = Mathf.Abs(x);
        float abY = Mathf.Abs(y);
        //Debug.Log("(" + x.ToString("0.0000") + "," + y.ToString("0.0000") + ")" + "[" + abX.ToString("0.0000") + "," + abY.ToString("0.0000") + "]");

        if (x > 0 && abX >= abY)
        {
            AnimateMovement(Direction.Right);
        }
        else if (x < 0 && abX >= abY)
        {
            AnimateMovement(Direction.Left);
        }
        else if (y < 0 && abX < abY)
        {
            AnimateMovement(Direction.Down);
        }
        else if (y > 0 && abX < abY)
        {
            AnimateMovement(Direction.Up);
        }  
    }

    public int GetMouseQuadrant()
    {
        float mx = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10f)).x;
        float my = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10f)).y;

        float px = transform.position.x;
        float py = transform.position.y;

        float abx = Mathf.Abs(px - mx);
        float aby = Mathf.Abs(py - my);

        //Debug.Log("PLAYER : (" + px.ToString("0.00") + "," + py.ToString("0.00") + ")" + " ||  MOUSE : " + "(" + mx.ToString("0.00") + "," + my.ToString("0.00") + ")");

        if (mx > px && abx > aby)    // if the mouse is right of the player and closer to the x Axis, attack right
        {
            animator.SetFloat("Input_X", 1);
            animator.SetFloat("Input_Y", 0);
            return 0;
        }
        else if (mx < px && abx > aby) // if the mouse is left of the player and closer to the x Axis, attack left
        {
            animator.SetFloat("Input_X", -1);
            animator.SetFloat("Input_Y", 0);
            return 1;
        }
        else if (my < py && abx < aby) // if the mouse is below of the player and closer to the y Axis, attack down
        {
            animator.SetFloat("Input_X", 0);
            animator.SetFloat("Input_Y", -1);
            return 2;
        }
        else if (my > py && abx < aby) // if the mouse is above of the player and closer to the y Axis, attack up
        {
            animator.SetFloat("Input_X", 0);
            animator.SetFloat("Input_Y", 1);
            return 3;
        }
        else
        {
            return 0;
        }
    }

    public int GetPlaying()
    {
        for(int i = 0; i < 5; i++)
        {
            if(playing[i] == true)
            {
                return i;
            }
        }
        return 0;
    }

    public void SetPlaying(int i)
    {
        for (int x = 0; x < 5; x++)
        {
            if (i != x)
            {
                playing[x] = false;
            }
            else if (i == x)
            {
                playing[x] = true;
            }
        }
    }

    public void AnimateAttack(Direction direction)
    {
        GetComponent<Player_Main>().SetTriggerBoxLocation(direction);
        animator.SetBool("attacking", true);
    }
    public void AnimateCasting(Direction direction)
    {
        GetComponent<Player_Main>().SetTriggerBoxLocation(direction);
        animator.SetBool("casting", true);
    }

    public void AnimateMovement(Direction direction)
    {
        
        //Debug.Log((int)direction + " " + direction);
        if(animator.speed < 1)
        {
            animator.speed = 1;
        }
        if (direction == Direction.None && !playing[4])
        {
            SetPlaying(4);
        }
        else if (direction == Direction.Right && !playing[0])
        {
            SetPlaying(0);
        }
        else if (direction == Direction.Left && !playing[1])
        {
            SetPlaying(1);
        }
        else if (direction == Direction.Down && !playing[2])
        {
            SetPlaying(2);
        }
        else if (direction == Direction.Up && !playing[3])
        {
            SetPlaying(3);
        }
        //lastDirection = direction;
      
    }
}
