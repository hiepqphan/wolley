using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAI : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] BoxCollider2D leftBorder;
    [SerializeField] BoxCollider2D rightBorder;

    float speed;
    float middle = 10.66667f;
    float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
        minX = leftBorder.transform.position.x;
        maxX = rightBorder.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 aim = new Vector2(middle, 0);
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

        bool outField = false;
        Vector2 v = ball.GetComponent<Rigidbody2D>().velocity;
        t = (10 - ballPos.y) / v.y;
        float x_predict = ballPos.x + v.x * t;
        if (x_predict < minX || x_predict > maxX)
            outField = true;

        if ((Mathf.Abs(x_dest - pos.x) > 0.2) && ((outField && ball.lastSlime.tag != "Player") || (!outField)))
        {
            Vector2 dir = new Vector2(x_dest - pos.x, 0).normalized;
            GetComponent<Rigidbody2D>().transform.position = pos + dir * speed * Time.deltaTime;
        }
    }
}
