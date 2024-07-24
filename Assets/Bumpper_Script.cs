using UnityEngine;

public class Bumpper_Script : MonoBehaviour
{

    void Start()
    {
        Rigidbody[] allChildren = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody child in allChildren)
        {
            if (child.gameObject != this.gameObject) // �θ� ������Ʈ�� Rigidbody�� �ƴ� ���
            {
                if (child.gameObject.GetComponent<BumpperChild>() == null)
                {
                    child.gameObject.AddComponent<BumpperChild>();
                }
            }
        }
    }

    
    void Update()
    {
        
    }
}
