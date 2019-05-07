using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameArcade : MonoBehaviour
{
    [SerializeField] Button pausebutton;
    [SerializeField] Button resumebutton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Time.timeScale == 1)
                pausebutton.onClick.Invoke();
            else
                resumebutton.onClick.Invoke();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }
}
