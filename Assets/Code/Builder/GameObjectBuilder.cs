using UnityEngine;
using Extensions;


namespace Builder
{
    public class GameObjectBuilder
    {
        protected GameObject _gameObject;
        public GameObjectBuilder() => _gameObject = new GameObject();

        protected GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;

        public VisualBuilder Visual => new VisualBuilder(_gameObject);

        public PhysicsBuilder Physics => new PhysicsBuilder(_gameObject);

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }
    }

    public class VisualBuilder : GameObjectBuilder
    {
        public VisualBuilder(GameObject gameObject) : base(gameObject) 
        { 

        }

        public VisualBuilder Mesh(Mesh mesh)
        {
            var component = _gameObject.GetOrAddComponent<MeshFilter>();
            component.sharedMesh = mesh;
            return this;
        }

        public VisualBuilder Material(Material material)
        {
            var component = _gameObject.GetOrAddComponent<MeshRenderer>();
            component.material = material;
            return this;
        }

    }

    public class PhysicsBuilder : GameObjectBuilder
    {
        public PhysicsBuilder(GameObject gameObject) : base(gameObject)
        {

        }

        public PhysicsBuilder RigidBody(float mass = 1.0f)
        {
            var component = _gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = mass;
            return this;
        }

        public PhysicsBuilder CapsuleCollider()
        {
            _gameObject.GetOrAddComponent<CapsuleCollider>();
            return this;
        }

    }
}
