using Player;


namespace Interfaces
{
    interface IPlayerFactory : IController
    {
        IController Create((IInputProvider horizontal, IInputProvider vertical) input);

        PlayerView GetPlayerView();
    }
}
