using System;
using UnityEngine;

namespace GMPR2512.Lesson04Scripting01
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private int _year = 1001;
        private float _seconds = 0f;
        private int _deathCount = 0;

        // Awake is called once when the script instance is being loaded
        void Awake()
        {
            Debug.Log($"I have arrisen, in the year of {_year}");
            _year += 1025;
        } 

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log($"Now it is the year {_year}");
        }

        // Update is called once per frame
        void Update()
        {
            _seconds += Time.deltaTime;
            if (_seconds >= 5f)
            {
                Debug.Log($"5 seconds have passed in the year {_year}");
                _seconds = 0f;
            }
        }

        // OnTriggerEnter2D is called when another collider enters the trigger (2D physics only)
        // Only if one of the colliders has "Is Trigger" enabled and at least one has a Rigidbody2D
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log($"'{collider.gameObject.name}' has entered the Death Zone");
            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.gravityScale = 0f;
                Destroy(rb);
            }
            _deathCount++;
            Debug.Log($"Total Deaths so far: {_deathCount}");
        }
    }
}
