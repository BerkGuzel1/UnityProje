using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2Scene");
    }
}
