﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slime_arcade : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Animator anim;

    float speed;
    float minX;
    float maxX;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        minX = -15f + 1.5f;
        maxX = 15f - 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((transform.position.x < minX && h == -1) || (transform.position.x > maxX && h == 1))
            h = 0;

        anim.SetFloat("horizontal_direction", -h);
        if (h != 0)
            anim.SetFloat("isMoving", 1);
        else
            anim.SetFloat("isMoving", -1);

        Vector2 dir = new Vector2(h, 0);
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