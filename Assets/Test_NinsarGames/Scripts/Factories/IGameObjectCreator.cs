using UnityEngine;

namespace Test_NinsarGames.Scripts.Factories
{
    public interface IGameObjectCreator
    {
        public GameObject PrimitiveFactory(GameObject prefab, char value, Vector3 position, Transform parent);
    }

}
