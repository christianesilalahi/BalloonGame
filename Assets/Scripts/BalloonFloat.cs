using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonFloat : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public float floatSpeed; // randomize this in Start
    public int scoreValue; // Score when clicked

    public float minSpeed;
    public float maxSpeed;


    // Static balloon counter
    public static int balloonSpawnCount = 0;

    public Sprite blueSprite;
    public Sprite greenSprite;
    public Sprite pinkSprite;
    public Sprite purpleSprite;
    public Sprite redSprite;
    public Sprite yellowSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Get the sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();

        // 🎈 Store your sprites in an array
        Sprite[] allOptions = new Sprite[] {
            blueSprite, greenSprite, pinkSprite,
            purpleSprite, redSprite, yellowSprite
        };
        List<Sprite> options = new List<Sprite>(allOptions);

        // List<string> names = new List<string>();
        // foreach (var sprite in options)
        // {
        //     names.Add(sprite.name);
        // }
        // Debug.Log("Available sprites: " + string.Join(", ", names));

        if (balloonSpawnCount < 3)
        {
            options.Remove(redSprite);
            options.Remove(purpleSprite);

        }
        if (balloonSpawnCount < 5)
        {
            options.Remove(purpleSprite);
        }

        // Pick one at random
        Sprite chosen = options[Random.Range(0, options.Count)];
        spriteRenderer.sprite = chosen;


        // other option on how to random
        // int randomIndex = Random.Range(0, options.Count);
        // Sprite chosen = options[randomIndex];

        balloonSpawnCount++;

        // 🎯 Decide score/speed by name
        string spriteName = chosen.name.ToLower(); // e.g., "balloon_circle_red"


        if (chosen == redSprite)
        {
            scoreValue = -20;
            minSpeed = 0.6f;
            maxSpeed = 0.9f;
        }
        else if (chosen == purpleSprite)
        {
            scoreValue = 50;
            minSpeed = 0.8f;
            maxSpeed = 1.2f;
        }
        else
        {
            scoreValue = 10;
            minSpeed = 0.4f;
            maxSpeed = 0.8f;
        }

        float speed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = new Vector2(0, speed);
        rb.gravityScale = 0f;

        float scale = Random.Range(1.2f, 1.8f); // adjust range as needed
        transform.localScale = new Vector3(scale, scale, 1f);



        // if (spriteName.Contains("red"))
        // {
        //     scoreValue = -20;
        //     rb.gravityScale = 0.25f;
        //     rb.drag = 1f;
        // }
        // else if (spriteName.Contains("purple"))
        // {
        //     scoreValue = 50;
        //     rb.gravityScale = -0.1f;
        //     rb.drag = 0.8f;
        // }
        // else
        // {
        //     scoreValue = 10;
        //     rb.gravityScale = -0.02f;
        //     rb.drag = 1.5f;
        // }
        // if (spriteName.Contains("red"))
        // {
        //     scoreValue = -20;
        //     floatSpeed = Random.Range(0.05f, 0.07f);  // slower
        // }
        // else if (spriteName.Contains("purple"))
        // {
        //     scoreValue = 50;
        //     floatSpeed = Random.Range(0.1f, 0.3f);  // medium speed
        // }
        // else
        // {
        //     scoreValue = 10;
        //     floatSpeed = Random.Range(0.01f, 0.03f);  // slowest
        // }

        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector2.up * floatSpeed * Time.deltaTime);

        if (transform.position.y > 6f)  // Adjust based on camera size
        {
            Destroy(gameObject);
        }
    }
}
