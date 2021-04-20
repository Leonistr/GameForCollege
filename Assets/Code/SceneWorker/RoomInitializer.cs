using UnityEngine;

namespace SceneWorker
{
    public class RoomInitializer
    {
        public GameObject CollegeScene;

        public RoomInitializer()
        {
            CollegeScene = Resources.Load<GameObject>(SceneManager.collegePath);
            CollegeScene = Object.Instantiate(CollegeScene);
        }
    }
}
