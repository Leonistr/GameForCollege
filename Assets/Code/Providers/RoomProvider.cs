using Interfaces;
using System;
using UnityEngine;

namespace Providers
{
    public class RoomProvider : IExecutable
    {
        public event Func<string> OnRoomEnter = delegate() { return string.Empty; };
        public event Action<string> OnRoomEnable;

        private string roomName;

        private void GetRoomName()
        {
            roomName = OnRoomEnter.Invoke();    
        }

        private void EnableRoom()
        {
            GetRoomName();
            OnRoomEnable.Invoke(roomName);
        }


        public void Execute(float deltaTime)
        {
            EnableRoom();
        }
    }
}
