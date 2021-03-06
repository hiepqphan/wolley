﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] Text scoreText;

    public GameObject lastSlime;

    int diff;
    float[] speedLevels = { 5f, 7f, 9f };
    float speed;
    bool goodToScore;

    // Start is called before the first frame update
    void Start()
    {
        goodToScore = true;
        diff = PlayerPrefs.GetInt("Difficulty");
        speed = speedLevels[diff];
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        GetComponent<Rigidbody2D>().gravityScale = 0;

        // Take advantage of this script to set score to 0
        PlayerPrefs.SetInt("Score", 0);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lastSlime = collision.gameObject;
        if (lastSlime.tag == "Opp")
        {
            Vector2 aim = new Vector2(lastSlime.GetComponent<SlimeAI>().targetx, 0);
            Vector2 pos = GetComponent<Rigidbody2D>().transform.position;
            Vector2 dir = (aim - pos).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            goodToScore = true;
        }
        else if (lastSlime.tag == "Player" && goodToScore)
        {
            int newScore = PlayerPrefs.GetInt("Score") + 1;
            PlayerPrefs.SetInt("Score", newScore);
            scoreText.text = newScore.ToString();
            goodToScore = false;
        }
    }
}
