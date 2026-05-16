using UnityEngine;

public class BoulderBehavior : MonoBehaviour
{
    [SerializeField] private float boulderSpeed = 5f;

    private float screenTop;
    private float screenBottom;
    private float screenLeft;
    private float screenRight;

    private ScoreManager scoreManager;

    void Start()
    {
        CalculateScreenBoundaries();

        scoreManager = Object.FindFirstObjectByType<ScoreManager>();
    }

    void Update()
    {
        MoveBoulder();

        RespawnBoulder();
    }

    private void CalculateScreenBoundaries()
    {
        Camera mainCamera = Camera.main;

        float camHeight = mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        //Vertical Bounds
        screenTop = mainCamera.transform.position.y + camHeight;
        screenBottom = mainCamera.transform.position.y - camHeight;

        //Horizontal Bounds
        screenLeft = mainCamera.transform.position.x - camWidth;
        screenRight = mainCamera.transform.position.x + camWidth;
    }

    private void MoveBoulder()
    {
        transform.Translate(Vector2.down * (boulderSpeed * Time.deltaTime));
    }

    private void RespawnBoulder()
    {
        float randomX = Random.Range(screenLeft, screenRight);

        if (transform.position.y < screenBottom)
        {
            transform.position = new Vector2(randomX, screenTop);
            scoreManager.AddScore();
        }


    }
}
