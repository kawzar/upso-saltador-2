using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIMananger : MonoBehaviour
{
    // Instancia de singleton
    public static UIMananger Instance { get; private set; }

    [SerializeField] private CanvasGroup gameOverCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [SerializeField] private float fadeInDuration = 0.25f;

    void Awake()
    {
        // Inicializacion del singleton
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator FadeInGameOver_Routine()
    {
        gameOverCanvas.gameObject.SetActive(true);

        while (gameOverCanvas.alpha < 1.0f)
        {
            gameOverCanvas.alpha += 0.025f;
            yield return null;
        }
    }

    public void FadeInGameOver()
    {
        //StartCoroutine(FadeInGameOver_Routine());
        gameOverCanvas.gameObject.SetActive(true);
        gameOverCanvas.DOFade(1, fadeInDuration).OnComplete(() => gameOverCanvas.transform.DOShakeScale(fadeInDuration));
    }

    public void UpdateScoreText(string text)
    {
        scoreText.SetText(text);
    }

    public void UpdateHighScoreText(string text)
    {
        highScoreText.SetText(text);
    }
}
