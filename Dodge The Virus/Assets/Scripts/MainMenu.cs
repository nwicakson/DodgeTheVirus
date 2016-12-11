using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public Text textHighscore;
    public AudioClip sfx;
    public AudioClip backgroundMusic;
    private SoundManager soundManager;

    void Awake()
    {
        //TextAsset file = Resources.Load<TextAsset>("InitialSetting");
        //prettyJson = JsonMapper.ToObject(file.text);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
            textHighscore.text = PlayerPrefs.GetInt("highscore").ToString();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.PlayBackground(backgroundMusic);
    }

    public void Play()
    {
        soundManager.PlaySoundEffect(sfx);
        SceneManager.LoadScene("Play");
    }

    public void Exit()
    {
        soundManager.PlaySoundEffect(sfx);
        PlayerPrefs.Save();
        Application.Quit();
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("highscore");
        textHighscore.text = "0";
    }
}
