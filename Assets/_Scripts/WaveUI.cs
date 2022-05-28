using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        WaveManager.SharedInstance.onWaveChange.AddListener(RefreshText);
        RefreshText();
    }
    
    private void RefreshText()
    {
        _text.text = "Wave- " +
            (WaveManager.SharedInstance.MaxWaves - WaveManager.SharedInstance.WavesCount) +
            "/" + WaveManager.SharedInstance.MaxWaves;
    }
}
