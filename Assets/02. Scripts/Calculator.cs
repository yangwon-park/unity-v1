using UnityEngine;

namespace _02._Scripts
{
    public class Calculator : MonoBehaviour
    {
        public int number1;
        public int number2;
        
        int Add()
        {
            return number1 + number2;
        }
        
        int Subtract()
        {
            return number1 - number2;
        }
        
        void Multiply()
        {
            
        }
        
        void Divide()
        {
            
        }
        
        void Start()
        {
            var addResult = Add();
            var substractResult = Subtract();
            
            Debug.Log($"Add Result: {addResult}");
            Debug.Log($"Substract Result: {substractResult}");
        }
    }
}
