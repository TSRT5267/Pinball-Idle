using UnityEngine;

public class FireButton_Script : MonoBehaviour
{
    [SerializeField] private GameManager GM;




    private void OnMouseDown()
    {
        GM.SpawnBall();
    }
}
