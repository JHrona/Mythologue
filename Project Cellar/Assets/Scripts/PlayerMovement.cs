using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 targetPos;
    public float dashRange;
    public float speed;
    private Vector2 direction;
    private Animator animator;

    private enum Facing {UP, DOWN, LEFT, RIGHT};
    private Facing FacingDir = Facing.DOWN;

    public GameObject Player;
    public float DashRefill = 5;
    public float dash;
    public float maxDash;
    public Slider DashSlider;


    void Start()
    {
      SetDash();
      animator = GetComponent<Animator>();
    }
    
    void Update()
    {

        if(dash < 0)
        {
          dash = 0;
        }

        if(Player != null)
        {
          SetDash();
        }

        DashRefill -= Time.deltaTime;

        if(DashRefill < 0.0f)
        {
          dash +=1;
          DashRefill = 5;
          SetDash();
          if(dash > 2)
          {
            dash = 2;
          }
        }

        TakeInput();
        Move();
    }

    void SetDash()
    {
      DashSlider.value = CalculateDash();
    }
   // pohyb a rychlost
    private void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
       //rb.velocity = new Vector2(direction.x, direction.y);

        if (direction.x != 0 || direction.y != 0)
        {
          SetAnimatorMovement(direction);
        }
        else
      {
          animator.SetLayerWeight(1, 0);
      }
    }



    // bindy na klávesnici
   private void TakeInput()
    {
       direction = Vector2.zero;

       if(Input.GetKey(KeyCode.W))
       {
         direction += Vector2.up;
         FacingDir = Facing.UP;
        }
       if(Input.GetKey(KeyCode.A))
       {
         direction += Vector2.left;
         FacingDir = Facing.LEFT;
        }
       if(Input.GetKey(KeyCode.S))
       {
         direction += Vector2.down;
         FacingDir = Facing.DOWN;
        }
       if(Input.GetKey(KeyCode.D))
       {
         direction += Vector2.right;
         FacingDir = Facing.RIGHT;
        }
        if(Input.GetKeyDown(KeyCode.Space) && dash > 0.9)
        {
            dash -= 1;
            SetDash();
            Vector2 currentPos = transform.position;
            targetPos = Vector2.zero;
            if(FacingDir == Facing.UP)
             {
                 targetPos.y = 1;
              }
              else if (FacingDir == Facing.DOWN)
              {
                 targetPos.y = -1;
              }   
              else if (FacingDir == Facing.LEFT)
              {
                  targetPos.x = -1;
              }  
              else if (FacingDir == Facing.RIGHT)
              {
                  targetPos.x = 1;
              }   

         RaycastHit2D hit = Physics2D.Raycast(currentPos, targetPos, dashRange);

        
          if (hit.collider != null)
          {
              transform.position = hit.point;
          }
         else
           {   

          transform.Translate(targetPos * dashRange);
           }
       }
       
    }

  // float na animace
  private void SetAnimatorMovement(Vector2 direction)
  {
    animator.SetLayerWeight(1, 1);
    animator.SetFloat("xDir", direction.x);
    animator.SetFloat("yDir", direction.y);
  }



  private float CalculateDash()
  {
    return (dash / maxDash);
  }
}
