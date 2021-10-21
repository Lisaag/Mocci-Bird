using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject tapToStartMessage = null;
    [SerializeField] GameObject scoreUI = null;

    public static UIManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    public void SetUIStartGame()
    {
        tapToStartMessage.SetActive(true);
    }

    public void SetUIInGame()
    {
        tapToStartMessage.SetActive(false);
    }

    public void UpdateScore()
    {
        scoreUI.GetComponent<TextMeshProUGUI>().text = GameManager.Score.ToString();
    }
}
