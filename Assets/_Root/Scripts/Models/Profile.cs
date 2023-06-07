 
using Tools;

namespace Game.Models
{
    internal class Profile
    {
        public readonly SubscriptionProperty<GameState> _currentGameState;
        public readonly Car _car;
        public readonly IInventoryModel _inventory;

        public Profile(float carSpeed)
        {
            _car = new Car(carSpeed);
            _currentGameState = new SubscriptionProperty<GameState>();
            _inventory = new Inventory();
        }
        public Profile(GameState gameState, float carSpeed) : this(carSpeed) =>_currentGameState.Value = gameState;
    }
}
