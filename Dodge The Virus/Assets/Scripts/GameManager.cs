using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject endPanel;
    public Text scoreAtEndPanel;
	public float slowness;
    public AudioClip[] sfx;
    public AudioClip backgroundMusic;
    private SoundManager soundManager;

    public void Start()
    {
        endPanel.SetActive(false);
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        soundManager.PlayBackground(backgroundMusic);
    }

    public void EndGame ()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().checkHighscore();
        endPanel.SetActive(true);
        scoreAtEndPanel.text = "Score : " + GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().getScore();
        soundManager.PlaySoundEffect(sfx[1]);
        StartCoroutine(SlowThenPauseTime());
    }

    public void PlayAgain()
    {
        endPanel.SetActive(false);
        Time.timeScale = 1f;
        soundManager.PlaySoundEffect(sfx[0]);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        soundManager.PlaySoundEffect(sfx[0]);
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator SlowThenPauseTime()
    {
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;

        yield return new WaitForSeconds(1f / slowness);

        Time.timeScale = 0.001f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
    }
}
