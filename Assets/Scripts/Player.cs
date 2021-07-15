using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    [Header("Player movement speed")]
    public float speed;
    [Header("Player Jump height")]
    public float jumpForce;
     float direction ;
     private PlayerAnimations anim;
     private bool isJumping;
     public int health;
     public bool vulnerality;
     public SpriteRenderer player_sprite;
     private GameManager _gm;
    
    // Start is called before the first frame update
    void Start()
    {
        isJumping = false;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimations>();
        _gm = FindObjectOfType<GameManager>();

    }

   
    void Update()
    {
        PlayerMovement();
        PlayerJump();
        VulneralityBehaviour();
       if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
      
    }

    void VulneralityBehaviour()
    {
        if (vulnerality)
        {
            player_sprite.color = Color.Lerp(Color.white, Color.magenta, 0.5f);
        }
        else
        {
            player_sprite.color = Color.white;
        }
    }

    private void FixedUpdate()
    {
        rig.velocity =  new Vector2(direction*speed,rig.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 8)
        {
            isJumping = false;
        }
      
        if (other.gameObject.layer == 12)
        {
            health = 0;
        }

       
    }

  

   

    void PlayerMovement()
    {
        direction =  Input.GetAxisRaw("Horizontal");
       
        CheckPlayerDirection();
        CheckPlayerAnimations();
    }
    void CheckPlayerDirection()
    {
        if(direction>0)
       {
           transform.eulerAngles = new Vector2(0,0);
         
          
       }
        if(direction<0)
        {
            transform.eulerAngles = new Vector2(0, 180);
           
        }

    
    }

    void CheckPlayerAnimations()
    {
        if (!isJumping)
        {
            if (direction != 0)
            {
                anim.SetPlayerState(1);
            }
            else if(direction  == 0)
            {
                anim.SetPlayerState(0);
            }

        }
        else
        {
            anim.SetPlayerState(2);
        }
      
      
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            anim.SetPlayerState(2);
            rig.AddForce(Vector2.up*jumpForce,ForceMode2D.Impulse);
           
           
        }
    }

    public void GenerateDamage()
    {
        
        if (!vulnerality)
        {
            _gm.TakeDamage(health);
            health--;
            vulnerality = true;
            StartCoroutine("Respawn");
        }
        
        

    }

    IEnumerator Respawn()
    {
      
        
        yield return new WaitForSeconds(3f);
        player_sprite.enabled = true;
            player_sprite.color = new Color(255, 255, 255, 255);
            vulnerality = false;
    
    }

    IEnumerator BlinkPlayer()
    {
        
        player_sprite.enabled = false;
        yield return new WaitForSeconds(0.2f);
        player_sprite.enabled = true;
    }

   
}
