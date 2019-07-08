using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private int WaitToEndInSec = 5;
    private int numerOfEnemies = 0;
    private bool levelTimerFinished = false;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    [SerializeField] AudioClip winMusic;
    [SerializeField] AudioClip looseMusic;

    MusicPlayer musicPlayer;



    private void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();

        if(musicPlayer)
        {
            musicPlayer.GetComponent<AudioSource>().volume = PlayerPrefsControler.GetMasterVolume();
        }

        Time.timeScale = 1;
        if(winLabel != null)
        {
            winLabel.SetActive(false);
        }
        
        if(loseLabel != null)
        {
            loseLabel.SetActive(false);
        }
        
    }

    public void AttackerSpawned()
    {
        numerOfEnemies++;
    }

    public void AttackerKilled()
    {
        numerOfEnemies--;

        if(numerOfEnemies <= 0 && levelTimerFinished && FindObjectOfType<Lives>().GetLives() > 0)
        {
            StartCoroutine(HandleWinCondition());
            
        }
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);

        if (musicPlayer)
        {
            musicPlayer.GetComponent<AudioSource>().volume = 0;
        }

        GetComponent<AudioSource>().clip = winMusic;
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(WaitToEndInSec);
        FindObjectOfType<SceneLoader>().LoadNextScene();


    }

    public void HandleLoseCondition()
    {
        if (musicPlayer)
        {
            musicPlayer.GetComponent<AudioSource>().volume = 0;
        }

        GetComponent<AudioSource>().clip = looseMusic;
        GetComponent<AudioSource>().Play();
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void TimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    public void StopSpawners()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner attackerSpawner in attackerSpawners)
        {
            attackerSpawner.StopSpawning();
        }
    }

}
