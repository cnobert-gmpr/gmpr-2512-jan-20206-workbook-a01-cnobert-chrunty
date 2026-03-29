using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson05Coroutines01
{
    public class DeathZone : MonoBehaviour
    {
        // Reference to the spawn point where the ball will respawn
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _respawnDelay = 2f;

        void OnTriggerEnter2D(Collider2D collider2D)
        {
            // Check if the object entering the Death Zone is tagged as "Ball"
            if (collider2D.CompareTag("Ball"))
            {
                GameObject ballCollider = collider2D.gameObject;
                Debug.Log($"'{ballCollider.name}' has entered the Death Zone");
                // Start the coroutine to respawn the ball after a delay
                StartCoroutine(RespawnBall(ballCollider));
            }
        }

    // "StartCoroutine" must be passed a method that returns IEnumerator
    private IEnumerator RespawnBall(GameObject ball)
        {
            // Delay the code following this line
            yield return new WaitForSeconds(_respawnDelay);
            // Respawn the ball with no momentum
            Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
            if (ballRB != null)
            {
                ballRB.linearVelocity = Vector2.zero;
                ballRB.angularVelocity = 0f;
            }
            else
            {
                Debug.Log($"'{ball.name}' is missing a Rigidbody2D component");
            }
            ball.transform.position = _spawnPoint.position;
            Debug.Log($"'{ball.name}' has respawned at the spawn point");
        }
    }
}