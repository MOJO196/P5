using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    public GameObject crossfade;
    public static Level_Loader instance;
    public GameOverScreen gameOverScreen;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        crossfade.SetActive(true);
    }
    public Animator transition;
    public float transtionTime = 1f;

    public void LoadNextLevel ()
    {
        GameStats.currentLevel++;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));        
    }

    public void ReloadLevel ()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void SetCurrentScene (int level)
    {
        GameStats.currentLevel = level;

        SceneManager.LoadScene(level);
    }

    public void Restart ()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Menu ()
    {
        yield return new WaitForSeconds(5);
        GameStats.currentLevel = 0;
        GameStats.score = 0;
        GameStats.health = 3;
        GameStats.lifes = 3;
        yield return new WaitForSeconds(transtionTime);
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transtionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
