using UnityEngine;
using System.Collections.Generic;
using Providers;


namespace SceneWorker
{
    public class RoomController
    {
        Dictionary<string, GameObject> rooms = new Dictionary<string, GameObject>();
        private RoomProvider _roomProvider;
        public RoomController(SceneInitializer scene, RoomProvider roomProvider)
        {
            _roomProvider = roomProvider;
            var sceneObject = scene.GetRooms().GetComponentInParent<Transform>();
            
            for (int i = 0; i < sceneObject.childCount; i++)
            {
                var cabinet = sceneObject.GetChild(i);
                if (cabinet.childCount > 1)
                {
                    for (int j = 0; j < cabinet.childCount; j++)
                    {
                        rooms[cabinet.GetChild(j).gameObject.name] = cabinet.GetChild(j).gameObject;
                    }
                }
                else
                {
                    rooms[cabinet.gameObject.name] = cabinet.gameObject;
                }
            }
            _roomProvider.OnRoomEnable += ActivateRooms;
        }

        public void DeactivateRooms(string roomName)
        {
            if (rooms.ContainsKey(roomName))
            {
                rooms[roomName].SetActive(false);
            }
        }

        public void ActivateRooms(string roomName)
        {
            if (rooms.ContainsKey(roomName))
            {
                rooms[roomName].SetActive(true);
                Debug.LogError(rooms[roomName].activeInHierarchy);
            }
        }
    }
}
