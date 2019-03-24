using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector2 startV = new Vector2(0f, 5f);

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = startV;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
