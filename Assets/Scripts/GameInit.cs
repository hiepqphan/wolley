using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    [SerializeField] Toggle[] toggles;
    [SerializeField] Toggle soundToggle;
    [SerializeField] Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        int diff = PlayerPrefs.GetInt("Difficulty");
        toggles[diff].isOn = true;
        toggles[(diff + 1) % 3].isOn = false;
        toggles[(diff + 2) % 3].isOn = false;

        PlayerPrefs.SetInt("Score", 0);

        if (PlayerPrefs.GetInt("Sound") == 1)
            soundToggle.isOn = true;
        else
            soundToggle.isOn = false;

        if (PlayerPrefs.GetInt("Sound") == 0)
            cam.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
