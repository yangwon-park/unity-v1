using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _02._Scripts.Math
{
    public class GenerateTile : MonoBehaviour
    {
        public GameObject tilePrefab;
        public int rows = 5, cols = 5;
        public Button[] buttons;
        public static int turretIndex;

        private void Awake()
        {
            buttons[0].onClick.AddListener(() => ChangeIndex(0));
            buttons[1].onClick.AddListener(() => ChangeIndex(1));
            buttons[2].onClick.AddListener(() => ChangeIndex(2));
            buttons[3].onClick.AddListener(() => ChangeIndex(3));
            buttons[4].onClick.AddListener(() => ChangeIndex(4));
        }

        private IEnumerator Start()
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    var pos = new Vector3(i, 0, j);

                    var tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                    var componentInChildren = tile.GetComponentInChildren<Renderer>();

                    componentInChildren.material.color = 
                        (i + j) % 2 == 0 ? Color.white : Color.black;
                    
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
        
        private void ChangeIndex(int index)
        {
            turretIndex = index;
        }
    }
}