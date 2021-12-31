using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("9_ClassesChallenge.Tests")]
namespace _9_ClassesChallenge
{
    internal class Human2
    {
        private string firstName = "Pat";
        private string lastName = "Smyth";
        private string eyeColor;
        private int age;

        public Human2(string firstName, string lastName, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        public Human2(string firstName, string lastName, string eyeColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            
        }

        public Human2(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public string AboutMe2()
        {
            if (age == 0 && eyeColor == null)
                return $"My name is {firstName} {lastName}.";
            else if (eyeColor == null)
                return $"My name is {firstName} {lastName}. My age is {age}";
            else if (age == 0)
                return $"My name is {firstName} {lastName}. My eye color is {eyeColor}.";
            else 
                return $"My name is {firstName} {lastName}. My age is {age}. My eye color is {eyeColor}.";
        }

        private int _weight;
        public int Weight
        {
            get { return this._weight; }

            set
            {
                this._weight = value;
                if (this._weight < 0 || this._weight >= 400)
                    this._weight = 0;
            }
        }
    }
}