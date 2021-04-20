using System.Collections.Generic;
using UnityEngine;


namespace Managers
{
    public class RoomManager
    {
        public const string ROOM_ONE = "Room1";
        public const string ROOM_TWO = "Room2";
        public const string ROOM_ONE_BUILDING = "room1";
        public const string ROOM_TWO_BUILDING = "room2";

        public static Dictionary<int, Transform> roomNumbers = new Dictionary<int, Transform>();

        public static void GetRoomsPosition()
        {

            var room = GameObject.FindGameObjectWithTag("RoomEntrance");
            if (room == null)
            {
                return;
            }
            var rooms = room.GetComponentsInChildren<Transform>();
            if (rooms.Length == 0)
            {
                return;
            }
            for (int i = 1; i < rooms.Length; i++)
            {
                roomNumbers[i] = rooms[i];
            }
            if (roomNumbers.Count <= 0)
            {
                throw new System.ArgumentNullException("Check for tags and objects, dictionary haven't found one");
            }
        }
    }
}
