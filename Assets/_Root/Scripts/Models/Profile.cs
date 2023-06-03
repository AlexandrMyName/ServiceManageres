
using Tools;

namespace Game.Models
{
    internal class Profile
    {
        public readonly SubscriptionProperty<GameState> _currentGameState;
        public readonly Car _car;


        public Profile(GameState gameState)
        {
            _currentGameState = new SubscriptionProperty<GameState>();
            _currentGameState.Value = gameState;
        }
        public Profile(GameState gameState, float carSpeed) : this(gameState)
        {
            _car = new Car(carSpeed);
        }
    }
}
