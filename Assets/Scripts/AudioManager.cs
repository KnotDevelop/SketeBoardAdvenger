using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource bg;
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource gameOver;
    [SerializeField] AudioSource hit;
    [SerializeField] AudioSource skate;
    [SerializeField] AudioSource score;

    private void Awake()
    {
        instance = this;
    }
    public void Play_BG() 
    {
        bg.Play();
    }
    public void Stop_BG()
    {
        bg.Stop();
    }
    public void Play_Click() 
    {
        click.Play();
    }
    public void Play_GameOver() 
    {
        gameOver.Play();
    }
    public void Play_Hit() 
    {
        hit.Play();
    }
    public void Play_Skate() 
    {
        skate.Play();
    }
    public void Stop_Skate()
    {
        skate.Stop();
    }
    public void Play_Score()
    {
        score.Play();
    }
    public void OpenAllAudio()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioVolume>().OpenSound();
        }
    }
    public void CloseAllAudio()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<AudioVolume>().CloseSound();
        }
    }
}
