using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float posXBefore;

    void Start()
    {
        posXBefore = transform.parent.position.x;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        sprite.flipX = posXBefore < transform.position.x;

        posXBefore  = transform.position.x;
       
    }


}
