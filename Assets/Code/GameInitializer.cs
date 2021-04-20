using Player;
using InputControllers;
using WorldData;
using CameraSpace;
using Moral;
using Providers;
using Builder;
using Managers;
using SceneWorker;
using Quests;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Texts;


namespace MainGamePart
{
    class GameInitializer
    {
        #region Constructor

        public GameInitializer(Controllers controllers, Data data)
        {
            var roomProvider = new RoomProvider();
            var cameraProvider = new CameraProvider();
            var moralProvider = new MoralProvider();
            var questAndTextProvider = new QuestAndTextProvider();
            SceneWorkerInitializer sceneWorkerInitializer = new SceneWorkerInitializer(roomProvider);
            RoomManager.GetRoomsPosition();
            var playerFactory = new PlayerFactory(data.PlayerData, moralProvider, roomProvider);
            var inputInitializer = new InputControllerInitializer();
            var playerInitializer = new PlayerInitializer(playerFactory, inputInitializer.GetInput(), moralProvider);
            var inputController = new InputController(inputInitializer.GetInput());
            var playerController = playerInitializer.GetController();
            var cameraFactory = new CameraFactory(data.CameraData, playerInitializer.GetPlayerView());
            var cameraInitializer = new CameraInitializer(cameraFactory, cameraProvider);
            var cameraController = cameraInitializer.GetController();
            var textFactory = new TextFactory(data.TextData, cameraInitializer.GetCameraView());
            var textInitializer = new TextInitializer(textFactory, questAndTextProvider);
            var textController = textInitializer.GetController();
            var questFactory = new QuestFactory(data.QuestDatas[0], textInitializer.GetTextView().gameObject);
            var questInitializer = new QuestInitializer(questFactory, questAndTextProvider);
            var questController = questInitializer.GetController();
            var moralFactory = new MoralFactory(data.MoralData, moralProvider);
            var moralInitializer = new MoralInitializer(moralFactory, playerInitializer.GetPlayerView(), moralProvider);
            var moralController = moralInitializer.GetController();
            
            controllers.AddController(textInitializer);
            controllers.AddController(textController);
            controllers.AddController(questInitializer);
            controllers.AddController(questController);
            controllers.AddController(roomProvider);
            controllers.AddController(sceneWorkerInitializer);
            controllers.AddController(moralProvider);
            controllers.AddController(moralFactory);
            controllers.AddController(moralInitializer);
            controllers.AddController(moralController);
            controllers.AddController(inputInitializer);
            controllers.AddController(inputController);
            controllers.AddController(cameraController);
            controllers.AddController(playerFactory);
            controllers.AddController(playerController);
            controllers.AddController(playerInitializer);
            controllers.AddController(questAndTextProvider);
        }

        #endregion
    }
}
