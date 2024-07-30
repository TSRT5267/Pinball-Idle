using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("PlayScene");
        GameManager.instance.playTime = 0f;
        GameManager.instance.Money = 10;
        
    }

    public void GameExit()
    {
        Application.Quit();
    }  
}
