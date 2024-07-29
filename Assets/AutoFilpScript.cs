using UnityEngine;
using UnityEngine.UI;

public class AutoFilpScript : MonoBehaviour
{
    [SerializeField] private FlipperScript flipper;
    [SerializeField] private bool onAutoFilp= false;
    [SerializeField] private float flipCooldown = 0.5f;  // ��Ÿ�� ����
    private bool canFlip = true;  // ���۰� ������ �� �ִ� �������� ����



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onAutoFilp && canFlip)
        {
            flipper.Flip();
            canFlip = false;
            Invoke("ResetFlip", flipCooldown);  // 0.5�� �� �ٽ� ������ �� �ֵ��� ����
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
