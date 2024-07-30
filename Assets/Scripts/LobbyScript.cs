using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
        GameManager.instance.playTime = 0f;
    }

    public void GameExit()
    {
        Application.Quit();
    }  
}
