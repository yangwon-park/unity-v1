using UnityEngine;

namespace _02._Scripts
{
    public class Calculator : MonoBehaviour
    {
        [SerializeField] private int number1;
        [SerializeField] private int number2;

        public int Number1
        {
            get => number1;
            set => number1 = value;
        }
        
        public int Number2
        {
            get => number2;
            set => number2 = value;
        }

        private int Add()
        {
            return number1 + number2;
        }

        private int Subtract()
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