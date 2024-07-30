using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private Text playtime ;

   
    void Update()
    {
        float totalSeconds = GameManager.instance.playTime;

        int hours = Mathf.FloorToInt(totalSeconds / 3600); // 1�ð� = 3600��
        int minutes = Mathf.FloorToInt((totalSeconds % 3600) / 60); // ���� �ʿ��� �� ���� ���
        int seconds = Mathf.FloorToInt(totalSeconds % 60); // ���� �ʿ��� �� ���� ���
        

        string timeFormatted = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        playtime.text = timeFormatted;
    }
}
