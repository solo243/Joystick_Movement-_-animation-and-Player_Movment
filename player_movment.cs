using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movment : MonoBehaviour
{
    
    public float moveforce = 10f;
    public float jumpforce = 5f;
    public float jump;
    private Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer src;
    public KeyCode Jumpkey;
    private string run = "running";
    private string attack_1 = "attack_2";
    float movmentx;


private void Awake(){
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    src = GetComponent<SpriteRenderer>();
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        movmentx = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movmentx,0f,0f)*Time.deltaTime*moveforce;
        AnimatePlayer();
       


      if ( Input.GetKeyDown(KeyCode.W)){
        Debug.Log("presssed suceess");
        anim.SetBool("attack_2",true);
       }if (Input.GetKeyUp(KeyCode.W))
        {
        anim.SetBool("attack_2",false);
        Debug.Log("attack_1 is on ");
        }
    }

    void AnimatePlayer()
    {
        if (movmentx > 0)
        {
            anim.SetBool("running",true);
            src.flipX = false;
        }
        else if (movmentx < 0)
        {
            anim.SetBool("running",true);
             src.flipX = true;
        }
        else 
        {
              anim.SetBool("running",false);
        }

    }



   
}
