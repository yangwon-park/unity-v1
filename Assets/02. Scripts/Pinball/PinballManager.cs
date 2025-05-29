using UnityEngine;

namespace _02._Scripts.Pinball
{
    public class PinballManager : MonoBehaviour
    
    {
        [SerializeField] private Rigidbody2D leftBarRb;
        [SerializeField] private Rigidbody2D rightBarRb;
            
        void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                leftBarRb.AddTorque(30f);
            }
            else
            {
                leftBarRb.AddTorque(-25f);
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rightBarRb.AddTorque(-30f);
            }
            else
            {
                rightBarRb.AddTorque(25f);
            }
        }
    }
}
