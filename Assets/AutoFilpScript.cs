using UnityEngine;
using UnityEngine.UI;

public class AutoFilpScript : MonoBehaviour
{
    [SerializeField] private FlipperScript flipper;
    [SerializeField] private bool onAutoFilp= false;
    [SerializeField] private float flipCooldown = 0.5f;  // 쿨타임 설정
    private bool canFlip = true;  // 필퍼가 뒤집을 수 있는 상태인지 추적



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onAutoFilp && canFlip)
        {
            flipper.Flip();
            canFlip = false;
            Invoke("ResetFlip", flipCooldown);  // 0.5초 후 다시 뒤집을 수 있도록 설정
        }
    }

    private void ResetFlip()
    {
        canFlip = true;
    }
    public bool OnAutoFilp
    {
        get
        {
            return OnAutoFilp;
        }
        set
        {
            OnAutoFilp = value;
        }

    }
}
