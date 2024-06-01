using UnityEngine;

public class Apple : MonoBehaviour
{
    //public GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            FindObjectOfType<GameManager>().GetApple();
            //gameManager.GetApple();
            //SendMessage("G");
        }
    }
}
