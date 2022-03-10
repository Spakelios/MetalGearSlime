using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject openControls;
    public GameObject closeControls;

    public void startGame()
    {
        SceneManager.LoadScene("Final Build");
    }

    public void openControl()
    {
        openControls.SetActive(true);
        closeControls.SetActive(false);
    }

    public void ReturnToMenu()
    {
        openControls.SetActive(true);
        closeControls.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}