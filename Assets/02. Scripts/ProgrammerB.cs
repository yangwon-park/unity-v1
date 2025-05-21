using UnityEngine;

namespace _02._Scripts
{
    public class ProgrammerB : MonoBehaviour
    {
        [SerializeField] private ProgrammerA programmerA;
        
        void Start()
        {
            programmerA.number2 = 20;
            
            Debug.Log($"ProgrammerB Number2 :: {programmerA.number2}");
        }
    }
}