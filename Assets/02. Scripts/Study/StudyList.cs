using System.Collections.Generic;
using UnityEngine;

namespace _02._Scripts.Study
{
    public class StudyList : MonoBehaviour
    {
        public List<int> _listNumber = new() { 1, 2, 3, 4, 5 };

        void Start()
        {
            _listNumber.Add(1);
            _listNumber.Add(2);
            _listNumber.Add(3);
            _listNumber.Add(4);
            _listNumber.Add(5);
            
            Debug.Log($"List Count :: {_listNumber.Count}");
            Debug.Log($"List Last Item :: {_listNumber[^1]}");

            var calculator = new Calculator();
            
            calculator.Number1 = 10;
            
            Debug.Log($"Calculator Number1 :: {calculator.Number1}");
        }
    }
}