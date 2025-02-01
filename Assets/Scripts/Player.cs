using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float RotateSpeed;
    [SerializeField] private AudioClip MoveClip, LoseClip;
    [SerializeField] private GameplayManager gameplayManager;
    [SerializeField] private GameObject ExplosionPrefab;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RotateSpeed *= -1f;
            SoundManager.instance.PlaySound(MoveClip);
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Instantiate(ExplosionPrefab, transform.GetChild(0).position, Quaternion.identity);
            gameplayManager.GameOver();
            Destroy(gameObject);
            return;
        }
    }
}
