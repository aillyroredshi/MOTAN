using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
 
    public float speedx;
    public float jumpspeedy;
   
    SpriteRenderer _spriteRenderer;
 
    public void LoadScene(string sceneName)
    {
 
    }
    

    bool facingRight, Jumping, IsGrounded, isFalling;
  
    float speed;
    private coins cs;
    private Animator anim;
    private WinGame ws;
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        facingRight = true;
        cs = GetComponent<coins>();
    }



    // Update is called once per frame
    void Update()
    {
        //IsGrounded = true;
        MovePlayer(speed);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            speed = -speedx;
            facingRight = false;
        }
        MovePlayer(speed);
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            speed = 0;
        }
        //
        MovePlayer(speed);
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            speed = speedx;
            facingRight = true;
        }
        MovePlayer(speed);
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            speed = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isFalling == false)
        {

            //rb.velocity.y = jumpspeedy;
                rb.AddForce(new Vector2(rb.velocity.x, jumpspeedy));
               // Jumping = true;
                anim.SetInteger("State", 3);
            isFalling = true;
        }

    
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isFalling = false;
        }

        if (speed > 0 || speed < 0)
        {
            //facingRight = !facingRight;
            //Vector3 temp = transform.localScale;
            //temp.x = facingRight ? 0.3f: -0.3f;
            //transform.localScale = temp;

            _spriteRenderer.flipX = !facingRight;

        }

    }


    void MovePlayer(float playerSpeed)
    {
        //
        if (playerSpeed < 0 && !Jumping || playerSpeed > 0 && !Jumping)
        {
            anim.SetInteger("State", 2);
        }
        if (playerSpeed == 0 && !Jumping)
        {
            anim.SetInteger("State", 0);
        }
        rb.velocity = new Vector3(speed, rb.velocity.y, 0);

    }
    public Texture btnTexture;
    void OnCollisionEnter2D(Collision2D ot)
    {

        if (ot.gameObject.tag == "Win")
        {
           


            //ws = GetComponent<WinGame>();
            SceneManager.LoadScene("Win");
           
            //IsGrounded = true;
            //Jumping = false;
            //anim.SetInteger("State", 0);
        }
        if (ot.gameObject.tag == "Lose")
        {

            //Destroy(gameObject,3);
            SceneManager.LoadScene("Menu");
            // IsGrounded = true;
            // DestroyObject(gameObject);
            //Application.Quit();
        }
        if(ot.gameObject.tag == "Coins")
        {
            Destroy(gameObject);
         
        }

    }


    public void walkleft()
    {
        
            speed = -speedx;

        anim.SetInteger("State", 2);
        facingRight = false;

    }
    public void walkright()
    {
        anim.SetInteger("State", 2);
        speed = speedx;
        facingRight = true;
    }
    public void stopmoving()
    {
        speed = 0;
    }
  
    public void jump()
    {
        if (IsGrounded == false)
        {       
            Jumping = true;
           // IsGrounded = true;
            rb.AddForce(new Vector2(rb.velocity.x, jumpspeedy));
            anim.SetInteger("State", 3);
            //if(IsGrounded== true)
            //{
            //    anim.SetInteger("State", 1);
            //    rb.AddForce(new Vector2(rb.velocity.x, 0));
            //}
            //IsGrounded = false;
            //rb.AddForce(new Vector2(rb.velocity.x, jumpspeedy));

        }
      
     
    }
    void ifcollision()
    {
 
        isFalling = false;
    }

    //void OnTriggerEnter(Collider2D other)
    //{
    //    if (other.gameObject.tag=="Coins")
    //    {
    //        Destroy(gameObject);
    //        cs.coin += 1;
    //    }
    //}


}