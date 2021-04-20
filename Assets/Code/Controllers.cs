using Interfaces;
using System.Collections.Generic;


namespace MainGamePart
{
    public class Controllers : IExecutable, ICleanable, IInitializable
    {
        #region Fields

        private List<IExecutable> _executables = new List<IExecutable>();
        private List<ICleanable> _cleanables = new List<ICleanable>();
        private List<IInitializable> _initializables = new List<IInitializable>();

        #endregion

        #region Methods

        public Controllers AddController(IController controller)
        {
            if (controller is IExecutable executable)
            {
                _executables.Add(executable);
            }
            if (controller is ICleanable cleanable)
            {
                _cleanables.Add(cleanable);
            }
            if (controller is IInitializable initializable)
            {
                _initializables.Add(initializable);
            }
            return this;
        }
        public void Clean()
        {
            for (int i = 0; i < _cleanables.Count; i++)
            {
                _cleanables[i].Clean();
            }
        }

        public void Execute(float deltaTime)
        {
            for (int i = 0; i < _executables.Count; i++)
            {
                _executables[i].Execute(deltaTime);
            }
        }

        public void Initialize()
        {
            for (int i = 0; i < _initializables.Count; i++)
            {
                _initializables[i].Initialize();
            }
        }

        #endregion
    }
}