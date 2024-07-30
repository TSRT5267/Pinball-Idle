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
        // 현재 재생중인 애니메이션 상태 가져오기
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        float currentAnimationTime = currentState.normalizedTime % 1; // 현재 애니메이션의 진행 시간 (0~1 범위)

        // 새로운 시간 설정
        float newTime = currentAnimationTime + (1f / currentState.length);

        // 애니메이션 시간 설정 및 재생
        animator.Play("SpawnCool", 0, newTime);
    }
}

