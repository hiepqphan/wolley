using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (tag == "Bottom")
        {
            SceneManager.LoadScene("Gameover");
        }
        else if (tag == "Top")
        {
            SceneManager.LoadScene("Mainscreen");
        }
        else if (collision.gameObject.tag == "Ball")
        {
            if (collision.gameObject.GetComponent<Ball>().lastSlime.tag == "Player")
                SceneManager.LoadScene("Gameover");
            else
                SceneManager.LoadScene("Mainscreen");
        }
    }
}
