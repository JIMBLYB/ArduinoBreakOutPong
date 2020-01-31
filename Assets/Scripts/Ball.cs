using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private GameObject ballSpawner;
    private ScoreKeeping UI;

    private Rigidbody2D rb2d;

    public float speed;
    public float bounceForce;
    public float reflect;
    public int penalty;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        ballSpawner = GameObject.Find("Players");
        UI = GameObject.Find("Score").GetComponent<ScoreKeeping>();
    }

    void Start()
    {
        if (Random.value <= .5)
        {
            UI.p1Turn = true;
            rb2d.AddForce(new Vector2(5 * speed, 0));
        }
        else
        {
            UI.p1Turn = false;
            transform.position = new Vector2(0, 0);
            rb2d.AddForce(new Vector2(-5 * speed, 0));
        }

    }

    void Update()
    {
        if (rb2d.velocity.x < 30)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x + 1, rb2d.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                float yDistance2 = -(other.transform.position.y - transform.position.y);
                rb2d.velocity = new Vector2(rb2d.velocity.x * -bounceForce, rb2d.velocity.y + (yDistance2 * reflect));
                break;

            case "Player1":
                UI.p1Turn = true;
                break;

            case "Player2":
                UI.p1Turn = false;
                break;

            case "TopWall":
                rb2d.velocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y);
                break;

            case "SideWall":
                if (UI.p1Turn)
                {
                    UI.p1Score = UI.p1Score / penalty;
                    UI.p1.text = UI.p1Score.ToString();
                }
                else
                {
                    UI.p2Score = UI.p2Score / penalty;
                    UI.p2.text = UI.p2Score.ToString();
                }
                ballSpawner.GetComponent<BallSpawner>().spawnBall();
                Object.Destroy(gameObject);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        UI.BlockBroken();
        Object.Destroy(other.gameObject);
    }
}
