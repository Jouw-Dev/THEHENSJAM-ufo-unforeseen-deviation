using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SurvivalTimer survivalTimer;
    [SerializeField] private WaveManager waveManager;

    [Header("Texts")]
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private TMP_Text survivalTimeText;

    private void Update()
    {
        UpdateWaveText();
        UpdateSurvivalTimeText();
    }

    private void UpdateWaveText()
    {
        waveText.text = $"WAVE {waveManager.CurrentWave}";
    }

    private void UpdateSurvivalTimeText()
    {
        int totalSeconds = Mathf.FloorToInt(survivalTimer.TimeSurvived);

        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        survivalTimeText.text = $"{minutes:00}:{seconds:00}";
    }
}
