using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject defeatCanvas;
    public GameObject victoryCanvas;
    public static GameManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ResourceManager.instance != null)
        {
            if(ResourceManager.instance.sacrificedWorkers >= ResourceManager.instance.sacGoal)
            {
                Victory();       
            }
        }
    }
    void pauseGame()
    {
        Time.timeScale = 0;

    }
    public void Defeated()
    {
        defeatCanvas.SetActive(true);
        pauseGame();
    }
    public void Victory()
    {
        victoryCanvas.SetActive(true);
        pauseGame();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
