using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonster : Damage
{
    private int lives = 5;
    private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

        if (collider.Length > 0)
        {
            dir *= -1f;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
        }

        if (lives < 1)
        {
            Die();
        }
    }
}
