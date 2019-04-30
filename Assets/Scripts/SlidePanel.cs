using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidePanel : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button gamemodeBackButton;
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject gamemodePanel;

    Animator startPanelAnim;
    Animator gamemodePanelAnim;

    // Start is called before the first frame update
    void Start()
    {
        startPanelAnim = startPanel.GetComponent<Animator>();
        gamemodePanelAnim = gamemodePanel.GetComponent<Animator>();

        startButton.onClick.AddListener(ShowGamemodes);
        gamemodeBackButton.onClick.AddListener(HideGamemodes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowGamemodes()
    {
        startPanelAnim.Play("MainPanel_slideout");
        gamemodePanelAnim.Play("GamemodePanel_slidein");
    }

    void HideGamemodes()
    {
        startPanelAnim.Play("MainPanel_slidein");
        gamemodePanelAnim.Play("GamemodePanel_slideout");
    }
}
