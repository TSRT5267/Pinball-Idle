using UnityEngine;

public class BumpperChild : MonoBehaviour
{
   [SerializeField] private Bumpper_Script parentObject; // �θ� ������Ʈ�� �Ҵ�
    private float lastTime; // ���������� AddMoney�� ȣ��� �ð��� ����
    private float interval = 0.1f; // AddMoney�� ȣ��� �ּ� ����

    private void Start()
    {
        parentObject = GetComponentInParent<Bumpper_Script>();
        lastTime = -interval; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        // ���� �ð��� ������ ȣ�� �ð� ���̰� ������ ���ݺ��� ũ�� AddMoney ȣ��
        if (Time.time - lastTime >= interval)
        {
            parentObject.AddMoney();
            lastTime = Time.time; // ������ ȣ�� �ð� ������Ʈ
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� �ð��� ������ ȣ�� �ð� ���̰� ������ ���ݺ��� ũ�� AddMoney ȣ��
        if (Time.time - lastTime >= interval)
        {
            parentObject.AddMoney();
            lastTime = Time.time; // ������ ȣ�� �ð� ������Ʈ
        }
    }


}
