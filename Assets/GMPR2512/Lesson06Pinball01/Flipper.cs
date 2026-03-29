using UnityEngine;

namespace GMPR2512.Lesson06Pinball01
{
    public class Flipper : MonoBehaviour
    {
        private HingeJoint2D _hingeJoint2D;

        void Awake()
        {
            _hingeJoint2D = GetComponent<HingeJoint2D>();
        } 
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow) && gameObject.name == "FlipperLeft")
            {
                _hingeJoint2D.useMotor = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && gameObject.name == "FlipperRight")
            {
                _hingeJoint2D.useMotor = true;
            }
            else
            {
                _hingeJoint2D.useMotor = false;
            }
        }
    }
}