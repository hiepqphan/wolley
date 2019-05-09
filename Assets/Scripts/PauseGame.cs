using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField] Slime player;
    [SerializeField] SlimeAI opp;
    [SerializeField] Ball ball;
    [SerializeField] GameObject pausepanel;
    [SerializeField] GameObject dimimage;
    [SerializeField] Button pausebutton;
    [SerializeField] Button resumebutton;

    float player_oldSpeed;
    Vector2 ball_oldVelocity;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LastPlayScene", SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!opp.getGameState())
                pausebutton.onClick.Invoke();
            else
                resumebutton.onClick.Invoke();
        }
    }

    // Pause game
    public void Pause()
    {
        // Save data
        player_oldSpeed = player.getSpeed();
        ball_oldVelocity = ball.GetComponent<Rigidbody2D>().velocity;

        // Stop any motion
        player.setSpeed(0);
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        opp.setGameState(true);
    }

    // Resume game
    public void Resume()
    {
        player.setSpeed(player_oldSpeed);
        ball.GetComponent<Rigidbody2D>().velocity = ball_oldVelocity;
        opp.setGameState(false);
    }
}
