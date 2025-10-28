using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OverworldInformation : MonoBehaviour
{
    [SerializeField] TMP_Text bestScoreText;
    [SerializeField] TMP_Text triesText;
    
    [SerializeField] string bestKey = "BestScore";
    [SerializeField] string triesKey = "PlayCount";
    
    void OnEnable() => Refresh();

    public void Refresh()
    {
        int best  = PlayerPrefs.GetInt(bestKey, 0);
        int tries = PlayerPrefs.GetInt(triesKey, 0);
        if (bestScoreText)  bestScoreText.text = best.ToString();
        if (triesText) triesText.text = tries.ToString();
    }

    // 에디터에서 값 미리 확인용(선택)
#if UNITY_EDITOR
    void OnValidate() { if (Application.isPlaying == false) Refresh(); }
#endif
    
}
