using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject strokesTextObject;
    TextMeshProUGUI strokesText;
    private int strokes = 0;

    void Start()
    {
        strokesText = strokesTextObject.GetComponent<TextMeshProUGUI>();
        UpdateScoreText();
    }

    void Update()
    {
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        strokesText.text = $"Strokes: {strokes}";
    }

    public void IncrementStrokes()
    {
        strokes++;
    }
}
