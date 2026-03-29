using System.Runtime.Serialization;
using UnityEngine;

namespace GMPR2512.Lesson02
{
    public class Square : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 0.1f;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(moveSpeed, 0, 0);
            transform.Rotate(moveSpeed, 0, 0);
        }
    }
}
