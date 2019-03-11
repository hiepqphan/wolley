using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] float minX = 4.5f;
    [SerializeField] float maxX = 16.8f;
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 5.4f;

    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // GetAxisRaw is unsmoothed input -1, 0, 1
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // Check boundaries
        Vector2 currentPos = GetComponent<Rigidbody2D>().transform.position;
        float curX = currentPos.x;
        float curY = currentPos.y;
        if ((curX <= minX && h < 0) || (curX >= maxX && h > 0))
            h = 0;
        if ((curY <= minY && v < 0) || (curY >= maxY && v > 0))
            v = 0;

        // normalize so going diagonally doesn't speed things up
        Vector2 direction = new Vector2(h, v).normalized;

        // translate
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
