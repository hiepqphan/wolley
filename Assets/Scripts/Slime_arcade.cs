using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime_arcade : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Animator anim;
    [SerializeField] Camera cam;

    float speed;
    float minX;
    float maxX;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7f;
        minX = -15f + 1.5f;
        maxX = 15f - 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = cam.ScreenToWorldPoint(touch.position);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                h = touchPos.x - transform.position.x;
            }
        }

        if ((transform.position.x < minX && h < 0) || (transform.position.x > maxX && h > 0))
            h = 0;

        anim.SetFloat("horizontal_direction", -h);
        if (h != 0)
            anim.SetFloat("isMoving", 1);
        else
            anim.SetFloat("isMoving", -1);

        Vector2 dir = new Vector2(h, 0).normalized;
        GetComponent<Rigidbody2D>().transform.Translate(dir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            int curScore = PlayerPrefs.GetInt("Score");
            PlayerPrefs.SetInt("Score", curScore + 1);
            scoreText.text = (curScore+1).ToString();
        }
    }
}
