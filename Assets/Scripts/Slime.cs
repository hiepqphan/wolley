using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] BoxCollider2D leftBorder;
    [SerializeField] BoxCollider2D rightBorder;
    [SerializeField] Animator anim;
  
    float minX;
    float maxX;
    float minY = 1.5f;
    float maxY = 7f;

    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        minX = leftBorder.transform.position.x;
        maxX = rightBorder.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPos = GetComponent<Rigidbody2D>().transform.position;
        float curX = currentPos.x;
        float curY = currentPos.y;

        // GetAxisRaw is unsmoothed input -1, 0, 1
        // Inputs for PCs
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // Inputs for iOS (or touch devices?)
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                v = touch.position.y - curY;
                h = touch.position.x - curX;
            }
        }

        // Check boundaries
        if ((curX <= minX && h < 0) || (curX >= maxX && h > 0))
            h = 0;
        if ((curY <= minY && v < 0) || (curY >= maxY && v > 0))
            v = 0;

        // normalize so going diagonally doesn't speed things up
        Vector2 dir = new Vector2(h, v).normalized;
        anim.SetFloat("horizontal_direction", dir.x);
        if (dir.x == 0)
            anim.SetFloat("isMoving", -1);
        else
            anim.SetFloat("isMoving", 1);

        // translate
        transform.Translate(dir * speed * Time.deltaTime);
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float newspeed)
    {
        speed = newspeed;
    }
}
