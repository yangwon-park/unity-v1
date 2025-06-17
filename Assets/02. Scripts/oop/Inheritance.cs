using System.Collections.Generic;
using UnityEngine;

namespace _02._Scripts.oop
{
    public class Inheritance : MonoBehaviour
    {
        public List<Student> students;
        public List<Soldier> soldiers;
        public List<Person> people;
        
        void Start()
        {
            for (var i = 0; i < 10; i++)
            {
                var student = new Student();
                people.Add(student);
                
                var soldier = new Soldier();
                people.Add(soldier);
            }
        }
        
        public void AllMove()
        {
            foreach (var person in people)
            {
                person.Walk();
            }
        }
    }
}