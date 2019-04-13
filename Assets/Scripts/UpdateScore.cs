using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    [SerializeField] GameObject winimage;
    [SerializeField] GameObject loseimage;

    // Start is called before the first frame update
    void Start()
    {
        int gameWon = PlayerPrefs.GetInt("Win");
        if (gameWon == 0)
        {
            winimage.SetActive(false);
            loseimage.SetActive(true);
        }
        else
        {
            winimage.SetActive(true);
            loseimage.SetActive(false);
        }

        // Update score
        GetComponent<Text>().text = (PlayerPrefs.GetInt("Score")+50*gameWon).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
