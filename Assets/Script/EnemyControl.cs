using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyControl : MonoBehaviour
{

    public float velocity;
    public Vector3 posFinal;
    private Vector3 posStart;
    private bool movementToFinal;

    void Start()
    {
        posStart = transform.position;
        movementToFinal = true;
    }

    
    void Update()
    {
        MovementEnemy();
    }

    private void MovementEnemy()
    {
        Vector3 positionFinal = (movementToFinal) ? posFinal : posStart;
        transform.position = Vector3.MoveTowards(transform.position, positionFinal, velocity * Time.deltaTime);
        if (transform.position == posFinal) movementToFinal = false;
        if (transform.position == posStart) movementToFinal = true;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
            
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControl>().TakesLifes();
        }
    }
}
