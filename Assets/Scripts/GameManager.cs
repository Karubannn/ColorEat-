using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Button FirstColorBtn;

    [SerializeField]
    private Button SecondColorBtn;

    [SerializeField]
    private Button ThirdColorBtn;

    void Start()
    {
        FirstColorBtn.onClick.AddListener(
            () => Coloriage.Instance.SelectColor(FirstColorBtn.GetComponent<Image>().color)
        );
        SecondColorBtn.onClick.AddListener(
            () => Coloriage.Instance.SelectColor(SecondColorBtn.GetComponent<Image>().color)
        );
        ThirdColorBtn.onClick.AddListener(
            () => Coloriage.Instance.SelectColor(ThirdColorBtn.GetComponent<Image>().color)
        );
    }
}
