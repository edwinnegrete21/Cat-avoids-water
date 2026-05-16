using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boulder"))
        {
            Object.FindFirstObjectByType<GameManager>().TriggerGameOver();

            Destroy(gameObject);
        }
      
        
    }
}
