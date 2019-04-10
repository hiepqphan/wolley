using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInit : MonoBehaviour
{
    [SerializeField] Toggle[] toggles;

    // Start is called before the first frame update
    void Start()
    {
        int diff = PlayerPrefs.GetInt("Difficulty");
        toggles[diff].isOn = true;
        toggles[(diff + 1) % 3].isOn = false;
        toggles[(diff + 2) % 3].isOn = false;

        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
