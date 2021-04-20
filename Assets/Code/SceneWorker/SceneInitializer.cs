using Interfaces;
using UnityEngine;


namespace SceneWorker
{
    public class SceneInitializer : IInitializable
    {
        private RoomInitializer _roomInitializer;

        public SceneInitializer()
        {
            _roomInitializer = new RoomInitializer();
        }
        public GameObject GetRooms()
        {
            return _roomInitializer.CollegeScene;
        }
        public void Initialize()
        {
            
        }
    }
}
