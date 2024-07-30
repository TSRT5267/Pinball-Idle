using UnityEngine;

public class BumpperChild : MonoBehaviour
{
   [SerializeField] private Bumpper_Script parentObject; // 부모 오브젝트를 할당
    private float lastTime; // 마지막으로 AddMoney가 호출된 시간을 저장
    private float interval = 0.1f; // AddMoney가 호출될 최소 간격

    private void Start()
    {
        parentObject = GetComponentInParent<Bumpper_Script>();
        lastTime = -interval; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // 현재 시간과 마지막 호출 시간 차이가 설정한 간격보다 크면 AddMoney 호출
        if (Time.time - lastTime >= interval)
        {
            parentObject.AddMoney();
            lastTime = Time.time; // 마지막 호출 시간 업데이트
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 현재 시간과 마지막 호출 시간 차이가 설정한 간격보다 크면 AddMoney 호출
        if (Time.time - lastTime >= interval)
        {
            parentObject.AddMoney();
            lastTime = Time.time; // 마지막 호출 시간 업데이트
        }
    }


}
