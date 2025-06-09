using System;
using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudySwitch : MonoBehaviour
    {
        [SerializeField] private int input1;
        [SerializeField] private int input2;
        [SerializeField] private int result;
        [SerializeField] private CalculationType calculationType;

        private void Start()
        {
            result = Calculate();
            
            Debug.Log($"결과 :: {result}");
        }
        
        private int Calculate()
        {
            return calculationType switch
            {
                CalculationType.PLUS => input1 += input2,
                CalculationType.MINUS => input1 -= input2,
                CalculationType.MULTIPLY => input1 *= input2,
                CalculationType.DEVIDE => input1 /= input2,
                _ => 0
            };
        }
        
        private enum CalculationType
        {
            PLUS, MINUS, MULTIPLY, DEVIDE  
        }
    }
}
