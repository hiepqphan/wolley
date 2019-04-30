using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] Slime player;
    [SerializeField] BoxCollider2D leftBorder;
    [SerializeField] BoxCollider2D rightBorder;
    [SerializeField] Animator anim;

    bool gamePaused;

    int diff;
    float[] speedLevels = { 5f, 8f, 10f };
    float speed;
    float middle = 15f;
    float minX, maxX;
    float optimalXLeft;
    float optimalXRight;

    public float targetx;

    // Start is called before the first frame update
    void Start()
    {
        diff = PlayerPrefs.GetInt("Difficulty");
        speed = speedLevels[diff];
        minX = leftBorder.transform.position.x;
        maxX = rightBorder.transform.position.x;
        optimalXLeft = leftBorder.transform.position.x + 1f;
        optimalXRight = rightBorder.transform.position.x - 1f;

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

        //// Calculate new position based on the target position
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        Vector2 ballPos = ball.GetComponent<Rigidbody2D>().transform.position;
        Vector2 pos = GetComponent<Rigidbody2D>().transform.position;

        Vector2 dir = (ballPos - pos);
        dir.y = 0;
        dir = dir.normalized;

        if (pos.x < minX || pos.x > maxX || gamePaused)
            dir.x = 0;

        anim.SetFloat("horizontal_direction", dir.x);
        if (Mathf.Abs(dir.x) > 0.2f) 
            anim.SetFloat("isMoving", 1);
        else
            anim.SetFloat("isMoving", -1);

        body.transform.position = Vector2.MoveTowards(body.transform.position, new Vector2(ballPos.x, pos.y), speed * Time.deltaTime);
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
