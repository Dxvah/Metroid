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
    public int points;
    public int numLifes;
    private bool vulnerable;
    private float inicialTime;
    public int levelTime;
    private int finalTime;
    public Canvas canvas;
    private HUDControl hud;
    public Canvas youWin;
    public ControlDataGame dataGame;
    int score = 0;
    bool facingRight;
    




    private void Start()
    {
        inicialTime = Time.time;
        vulnerable = true;
        physics = GetComponent<Rigidbody2D>();
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        animacion = GetComponent<Animator>();
        imagen = GetComponent<SpriteRenderer>();
        hud = canvas.GetComponent<HUDControl>();
        dataGame = GameObject.Find("Datos Juego").GetComponent<ControlDataGame>();
        
    }


    private void FixedUpdate()
    {
        float movementX = Input.GetAxis("Horizontal");
        Debug.Log(movementX);
        physics.velocity = new Vector2(movementX * velocity, physics.velocity.y);
        if (movementX < 0.0f && facingRight)
        {
            Flip();
        }
        else if (movementX > 0.0f && !facingRight)
        {
            Flip();
        }
        
    }
    private void Flip()
    {
        if (facingRight)
        {
            facingRight = false;
            imagen.flipX = true;
        }
        else
        {
            facingRight = true;
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
        if(GameObject.FindGameObjectsWithTag("PowerUp").Length == 0) WinGame();
        finalTime = (int)(Time.time - inicialTime);
        hud.SetTimeTxt(levelTime - finalTime);
        if (levelTime - finalTime < 0) GameOver();
        hud.SetPowerUpTxt(GameObject.FindGameObjectsWithTag("PowerUp").Length);
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
        dataGame.uWin = false;

    }
    public void TakesLifes()
    {
        if(vulnerable)
        {   
            vulnerable = false;
            numLifes --;
            hud.SetLifesTxt(numLifes);
            if(numLifes == 0) GameOver();
            Invoke("DoVulnerable", 1f);
            imagen.color = Color.red;
        }  
    }

    private void DoVulnerable()
    {
        vulnerable = true;
        imagen.color = Color.white;
    }


    public void IncreasePoints(int amount)
    {
        points += amount;

    }
    private void WinGame()
    {
        
        points = (numLifes * 100) + (levelTime - finalTime);
        //Debug.Log("You Win!" + (int) finalTime);
        youWin.gameObject.SetActive(true);
        dataGame.Score = score;
        dataGame.uWin = true;
    
    }

}

