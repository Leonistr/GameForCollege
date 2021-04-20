using Interfaces;
using Managers;
using Providers;


namespace SceneWorker
{
    public class SceneWorkerInitializer : IInitializable
    {
        private SceneInitializer _sceneInitializer;
        private RoomController _roomController;
        public SceneWorkerInitializer(RoomProvider roomProvider)
        {
            
            _sceneInitializer = new SceneInitializer();
            _roomController = new RoomController(_sceneInitializer, roomProvider);
        }

        public void Initialize()
        {
            
        }

        public RoomController GetRoomController()
        {
            return _roomController;
        }
    }
}
