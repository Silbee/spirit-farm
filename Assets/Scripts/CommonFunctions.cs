using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonFunctions : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void LoadMenu(Canvas loadingCanvas)
    {
        loadingCanvas.enabled = true;
        SceneManager.LoadScene(0);
    }

    
    public void StartGame(Canvas loadingCanvas)
    {
        loadingCanvas.enabled = true;
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        Application.Quit();
    }



    public void DisplayCanvas(Canvas canvas)
    {
        canvas.enabled = true;
    }


    public void CloseCanvas(Canvas canvas)
    {
        canvas.enabled = false;
    }


    public void ToggleCanvas(Canvas canvas)
    {
        canvas.enabled = !canvas.enabled;
    }


    public void SetTimeScale(float t)
    {
        Time.timeScale = t;
    }
}
