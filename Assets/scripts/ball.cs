using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public float speed = 100f;
    public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        score = 0;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketWidth)
    {
        //ascii art:
        //
        // 1 -0.5 0 0.5 1 <- x value
        //================== <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hit racket?
        if (collision.gameObject.tag == "Racket")
        {
            //Calculate hit Factor 
            float x = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            //Calculate direction, set length to 1 
            Vector2 dir = new Vector2(x, 1).normalized;
            //set Velocity with dir * speed 
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        if (collision.gameObject.tag == "Block")
        {
            score++;
            scoreText.text = score.ToString();
        }

    }
}
