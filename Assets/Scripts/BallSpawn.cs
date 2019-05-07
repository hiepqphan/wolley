using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    [SerializeField] GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(ball, new Vector2(-10, 10), Quaternion.identity);
    }
}
