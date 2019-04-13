using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] Slime player;
    [SerializeField] BoxCollider2D leftBorder;
    [SerializeField] BoxCollider2D rightBorder;

    bool gamePaused;

    int diff;
    float[] speedLevels = { 4f, 5f, 7f };
    float speed;
    float middle = 10.66667f;
    float minX, maxX;
    float optimalXLeft = 7f;
    float optimalXRight = 15.7f;

    public float targetx;

    // Start is called before the first frame update
    void Start()
    {
        diff = PlayerPrefs.GetInt("Difficulty");
        speed = speedLevels[diff];
        minX = leftBorder.transform.position.x;
        maxX = rightBorder.transform.position.x;
        targetx = middle;
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculating target position to aim the ball in the x-coordinate 
        Vector2 playerPos = player.GetComponent<Rigidbody2D>().transform.position;
        if (playerPos.x >= middle)
            targetx = Random.Range(optimalXLeft, playerPos.x - 0.5f);
        else
            targetx = Random.Range(playerPos.x + 0.5f, optimalXRight);

        // Calculate new position based on the target position
        Vector2 aim = new Vector2(targetx, 0);
        Vector2 ballPos = ball.GetComponent<Rigidbody2D>().transform.position;
        Vector2 pos = GetComponent<Rigidbody2D>().transform.position;
        Vector2 dest = ballPos - aim;

        float t = (10 - ballPos.y) / dest.y;

        float x_dest = ballPos.x+dest.x*t;
        if (x_dest < minX)
        {
            x_dest = minX;
        }
        else if (x_dest > maxX)
        {
            x_dest = maxX;
        }

        // Calculate if the ball will hit side boundaries
        bool outField = false;
        Vector2 v = ball.GetComponent<Rigidbody2D>().velocity;
        t = (12 - ballPos.y) / v.y;
        float x_predict = ballPos.x + v.x * t;
        float offset = 0.5f;
        if (x_predict < minX+offset || x_predict > maxX-offset)
            outField = true;

        // Move the slime
        Vector2 dir = new Vector2(x_dest - pos.x, 0).normalized;
        if (gamePaused)
            dir.x = 0;

        if (!outField)
            GetComponent<Rigidbody2D>().transform.position = pos + dir * speed * Time.deltaTime;
        else if (ball.lastSlime.tag == "Player")
            GetComponent<Rigidbody2D>().transform.position = pos + dir * (speedLevels[0] - 1) * Time.deltaTime;
        else
            GetComponent<Rigidbody2D>().transform.position = pos + dir * speed * Time.deltaTime;
    }

    public void setGameState(bool newstate)
    {
        gamePaused = newstate;
    }

    public bool getGameState()
    {
        return gamePaused;
    }
}
