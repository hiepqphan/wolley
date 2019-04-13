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
            PlayerPrefs.SetInt("Win", 0);
            SceneManager.LoadScene("Gameover");
        }
        else if (tag == "Top")
        {
            PlayerPrefs.SetInt("Win", 1);
            SceneManager.LoadScene("Gameover");
        }
        else if (collision.gameObject.tag == "Ball")
        {
            if (collision.gameObject.GetComponent<Ball>().lastSlime.tag == "Player")
            {
                PlayerPrefs.SetInt("Win", 0);
                SceneManager.LoadScene("Gameover");
            }
            else
            {
                PlayerPrefs.SetInt("Win", 1);
                SceneManager.LoadScene("Gameover");
            }
        }
    }
}
