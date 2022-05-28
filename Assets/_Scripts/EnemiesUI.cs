using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        EnemyManager.SharedInstance.onEnemyChange.AddListener(RefreshText);
        RefreshText();
    }

    private void RefreshText()
    {
        _text.text = "Remeaning Enemies- " + EnemyManager.SharedInstance.EnemyCount;
    }
}
