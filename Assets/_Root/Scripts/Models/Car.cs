
using System.Numerics;

namespace Game.Models
{
    internal class Car : IUpgradable
    {
         
        private readonly float _defaultSpeed;
        public Car(float speed)
        {
            _defaultSpeed = speed;
             
            Speed = speed;
        }

        public float Speed { get; set; }

        public float GetSpeed() => Speed;

        public void Restore()
        {
             Speed = _defaultSpeed;
        }
    }
}
