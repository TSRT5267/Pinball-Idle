using UnityEngine;

public class FireButton_Script : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        
        
    }

    private void Update()
    {
        animator.speed = 1f / GameManager.instance.SpawnDelay;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.instance.SpawnTimer++;
            SkipAnimationTime();
        }
    }


    private void OnMouseDown()
    {

        //GameManager.instance.SpawnBall();
        GameManager.instance.SpawnTimer++;
        SkipAnimationTime();


    }

    
    void SkipAnimationTime()
    {
        // ���� ������� �ִϸ��̼� ���� ��������
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        float currentAnimationTime = currentState.normalizedTime % 1; // ���� �ִϸ��̼��� ���� �ð� (0~1 ����)

        // ���ο� �ð� ����
        float newTime = currentAnimationTime + (1f / currentState.length);

        // �ִϸ��̼� �ð� ���� �� ���
        animator.Play("SpawnCool", 0, newTime);
    }
}

