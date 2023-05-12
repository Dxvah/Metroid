using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public int velocity;
    private Rigidbody2D physics;
    public int forceJump;
    public Canvas Canvas;
    private Animator animacion;
    private SpriteRenderer imagen;
    

    private void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        animacion = GetComponent<Animator>();
        imagen = GetComponent<SpriteRenderer>();
        
    }

    private void FixedUpdate()
    {
        float movementX = Input.GetAxis("Horizontal");  
        physics.velocity = new Vector2(movementX * velocity, physics.velocity.y);
        if (movementX < 0.0)
        {
            imagen.flipX = true;
        }
        else
        {
            imagen.flipX = false;
        }
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && TouchFloor())
        {
            physics.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
        }

        AnimacionPlayer();
    }


    private void AnimacionPlayer()
    {

        if (!TouchFloor()) animacion.Play("JumpPlayer");
        else if (physics.velocity.x > 1 || physics.velocity.x < -1 && physics.velocity.y == 0) animacion.Play("RunPlayer");
        else if (physics.velocity.x < 1 || physics.velocity.x > -1 && physics.velocity.y == 0) animacion.Play("IdlePlayer");


    }

    private bool TouchFloor()
    {
        RaycastHit2D touch = Physics2D.Raycast(transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return touch.collider != null;
    }

    public void GameOver()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Canvas.gameObject.SetActive(true);
        Time.timeScale = 0;

    }

}

