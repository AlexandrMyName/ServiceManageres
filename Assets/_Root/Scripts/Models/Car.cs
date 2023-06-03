
using System.Numerics;

namespace Game.Models
{
    internal class Car 
    {
        private float _speed;
       
        public Car(float speed)
        {
            _speed = speed;
            
        }
        public float GetSpeed() => _speed;
    }
}
