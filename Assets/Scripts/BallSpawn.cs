using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] GameObject ball;

    float[] spawnPosX = new float[2];
    float[] spawnPosY = new float[2];

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        InvokeRepeating("Spawn", 5f, 5f);

        spawnPosX[0] = -20f;
        spawnPosX[1] = 20f;

        spawnPosY[0] = 5f;
        spawnPosY[1] = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        float posX = Random.Range(spawnPosX[0], spawnPosX[1]);
        float posY = Random.Range(spawnPosY[0], spawnPosY[1]);
        if (posX > -16f && posX < 16f)
            posY = Random.Range(10f, spawnPosY[1]);

        Instantiate(ball, new Vector2(posX, posY), Quaternion.identity);
    }
}
