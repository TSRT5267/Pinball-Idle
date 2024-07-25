using UnityEngine;

public class FireButton_Script : MonoBehaviour
{

    private void OnMouseDown()
    {

        //GameManager.instance.SpawnBall();
        GameManager.instance.SpawnTimer--;
    }
}
