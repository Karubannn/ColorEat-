using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuPanel;

    [SerializeField]
    private GameObject HudPanel;

    [SerializeField]
    private GameObject BlackScreen;

    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void OnClickPlay()
    {
        SetupHud();
        MainMenuPanel
            .GetComponent<CanvasGroup>()
            .DOFade(0, .5f)
            .OnComplete(() =>
            {
                MainMenuPanel.SetActive(false);
                BlackScreen
                    .GetComponent<Image>()
                    .DOFade(0, .75f)
                    .OnComplete(() =>
                    {
                        HudPanel.SetActive(true);
                        HudPanel.GetComponent<CanvasGroup>().DOFade(1, .5f);
                    });
            });
    }

    private void SetupHud()
    {
        BlackScreen.GetComponent<Image>().DOFade(1, 0f);
        HudPanel.SetActive(false);
        HudPanel.GetComponent<CanvasGroup>().alpha = 0;
    }
}
