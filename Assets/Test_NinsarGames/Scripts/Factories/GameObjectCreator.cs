using System.Collections.Generic;
using UnityEngine;

namespace Test_NinsarGames.Scripts.Factories
{
    public class GameObjectCreator : IGameObjectCreator
    {
        private Dictionary<char, Color> _colorMapping;
        public GameObjectCreator()
        {
            _colorMapping = new Dictionary<char, Color>
            {
                { '1', Color.red },
                { '2', Color.yellow },
                { '3', Color.blue },
                { '4', Color.magenta }
            };
        }
        public GameObject PrimitiveFactory(GameObject prefab, char value, Vector3 position, Transform parent)
        {
            GameObject cube = Object.Instantiate(prefab, parent);
            cube.transform.localPosition = position;

            Renderer rend = cube.GetComponent<Renderer>();
            rend.material.color = _colorMapping.TryGetValue(value, out Color color) ?
                color : Color.white;

            return cube;
        }
    }

}
