using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private Text playtime ;

   
    void Update()
    {
        float totalSeconds = GameManager.instance.playTime;

        int hours = Mathf.FloorToInt(totalSeconds / 3600); // 1시간 = 3600초
        int minutes = Mathf.FloorToInt((totalSeconds % 3600) / 60); // 남은 초에서 분 단위 계산
        int seconds = Mathf.FloorToInt(totalSeconds % 60); // 남은 초에서 초 단위 계산
        

        string timeFormatted = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        playtime.text = timeFormatted;
    }
}
