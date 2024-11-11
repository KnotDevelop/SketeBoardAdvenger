using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] HorizontalLayoutGroup scoreHolder;
    [SerializeField] TextMeshProUGUI score_text;
    [SerializeField] TextMeshProUGUI finishScore_text;
    [SerializeField] GameObject finish_panel;

    [SerializeField] GameObject audio_btn;
    [SerializeField] GameObject audioMute_btn;
    public bool isAudio = true;

    private void Awake()
    {
        Instance = this;
    }
    public void AudioButton_Switch()
    {
        if (isAudio)
        {
            audio_btn.SetActive(false);
            audioMute_btn.SetActive(true);
            AudioManager.instance.CloseAllAudio();
            isAudio = false;
        }
        else
        {
            audio_btn.SetActive(true);
            audioMute_btn.SetActive(false);
            AudioManager.instance.OpenAllAudio();
            isAudio = true;
        }
    }
    private void Start()
    {
        ResetHorizontalLayout(scoreHolder);
    }
    public void UpdateScoreText(int _score)
    {
        score_text.text = _score.ToString();
        finishScore_text.text = _score.ToString();
        ResetHorizontalLayout(scoreHolder);
    }
    public void OpenFinish_Panel() 
    {
        finish_panel.SetActive(true);
    }
    public void ResetHorizontalLayout(HorizontalLayoutGroup _layoutGroup)
    {
        _layoutGroup.childControlWidth = false;
        _layoutGroup.childControlWidth = true;
    }
}
