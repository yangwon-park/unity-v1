using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _02._Scripts.Lotto
{
    public class LottoGenerator : MonoBehaviour
    {
        [SerializeField] private List<int> indices = new();
        [SerializeField] private int shakeCount = 1000;
        
        void Awake()
        {
            for (var i = 1; i < 46; i++)
            {
                indices.Add(i);
            }
        }
        
        IEnumerator Start()
        {
            for (var i = 0; i < shakeCount; i++)
            {
                var r1 = Random.Range(0, indices.Count);
                var r2 = Random.Range(0, indices.Count);
                
                (indices[r1], indices[r2]) = (indices[r2], indices[r1]);
                
                yield return new WaitForSeconds(0.025f);
            }
        }
        
        private void Shuffle()
        {
            for (var i = 0; i < shakeCount; i++)
            {
                var r1 = Random.Range(0, indices.Count);
                var r2 = Random.Range(0, indices.Count);
                
                (indices[r1], indices[r2]) = (indices[r2], indices[r1]);
            }
        }
    }
}
