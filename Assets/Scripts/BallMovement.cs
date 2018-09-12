using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public float baseMoveSpeed;
    public float bounceModifier;
    public float gravity;
    public float ballSize;

    Vector2 direction;

    Rigidbody2D rb;
    SpriteRenderer rend;
    float bounceForce;
    bool addBounce;
	// Use this for initialization
	void Start ()
    { 
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        OnSpawn();
	}

    // Update is called once per frame
    private void Update()
    {
        //respawn if ball goes off screen
        if (Mathf.Abs(transform.position.x) > 11)
        {
            Object.FindObjectOfType<BallManager>().SpawnNewBall();
            Destroy(gameObject);
        }
    }
    
    void FixedUpdate ()
    {
        //increase force after bouncing off of paddle
        if (addBounce)
        {
            rb.AddForce(direction * bounceForce, ForceMode2D.Impulse);
            addBounce = false;
            Debug.Log("Bounce of paddle");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //increase force after bouncing off of paddle
        if (collision.transform.tag == "Player")
        {
            direction = (transform.position - collision.transform.position).normalized;
            bounceForce = Mathf.Abs(direction.y);
            direction.y *= bounceModifier;
            direction.Normalize();
            addBounce = true;
            if ((transform.position.x < 0 && rb.velocity.x < 0)
                || (transform.position.x > 0 && rb.velocity.x > 0))
            {
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }
        }
    }

    void OnSpawn()
    {
        //reset position
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;

        //move in random direction
        int x = 1;
        if (Random.Range(0, 1f) >= 0.5f)
            x = -1;
        direction = new Vector2(x, Random.Range(-0.2f, 0.2f));

        rb.gravityScale = gravity;

        rb.AddForce(direction * baseMoveSpeed);

        transform.localScale = Vector3.one * ballSize;
    }
}
