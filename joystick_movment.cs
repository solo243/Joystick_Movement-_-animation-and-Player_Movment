using UnityEngine;

public class joystick_movment : MonoBehaviour
{
    
    public Animator anim;
    public SpriteRenderer src;
    private float horizontal;
    public float speed = 2f;
   
    private bool isFacingRight = true;
    public Joystick joystick;

    [SerializeField] public Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {


     
        horizontal = joystick.Horizontal;
AnimatePlayer();

        Flip();



         if ( Input.GetKeyDown(KeyCode.V)){
        Debug.Log("presssed suceess");
        anim.SetBool("Death",true);
       }if (Input.GetKeyUp(KeyCode.V))
        {
        anim.SetBool("Death",false);
        Debug.Log("attack_1 is on ");
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    void AnimatePlayer()
    {
        if ( horizontal > 0)
        {
            anim.SetBool("running",true);
           
        }
        else if ( horizontal < 0)
        {
            anim.SetBool("running",true);
             
        }
        else 
        {
              anim.SetBool("running",false);
        }

    }


    
}