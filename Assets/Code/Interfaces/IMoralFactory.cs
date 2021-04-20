using Moral;
using Player;


namespace Interfaces
{
    public interface IMoralFactory : IController
    {
        IController Create(PlayerView playerView);
        MoralView GetMoralView();
    }
}
