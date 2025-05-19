using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayGame(){
        Debug.Log("Start button clicked!");
        SceneManager.LoadScene(1);
    }


    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }


}
