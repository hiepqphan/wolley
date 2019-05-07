using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_arcade : MonoBehaviour
{
    [SerializeField] GameObject player;

    bool slimeTouched;
    float speed;
    float optimalXLeft;
    float optimalXRight;
    float middle;

    int diff;
    float[] speedLevels = { 3f, 5f, 7f };

    // Start is called before the first frame update
    void Start()
    {
        middle = 0;
        optimalXLeft = -15f + 1.5f;
        optimalXRight = 15f - 1.5f;
        diff = PlayerPrefs.GetInt("Difficulty");
        slimeTouched = false;
        speed = speedLevels[diff];

        Vector2 playerPos = player.GetComponent<Rigidbody2D>().transform.position;
        float targetx;
        if (playerPos.x >= middle)
            targetx = Random.Range(optimalXLeft, playerPos.x - 0.5f);
        else
            targetx = Random.Range(playerPos.x + 0.5f, optimalXRight);

        GetComponent<Rigidbody2D>().velocity = (new Vector2(targetx - transform.position.x, -5 - transform.position.y).normalized) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            slimeTouched = true;
        }

        if (collision.gameObject.tag == "DestroyCollider")
        {
            if (slimeTouched)
                GameObject.Destroy(gameObject);
        }
    }
}
