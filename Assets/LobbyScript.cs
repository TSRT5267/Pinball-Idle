using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }  
}
