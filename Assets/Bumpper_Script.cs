using UnityEngine;

public class Bumpper_Script : MonoBehaviour
{

    void Start()
    {
        Rigidbody[] allChildren = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody child in allChildren)
        {
            if (child.gameObject != this.gameObject) // 부모 오브젝트의 Rigidbody가 아닌 경우
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
