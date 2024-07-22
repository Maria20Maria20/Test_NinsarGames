using System;
using System.IO;
using Test_NinsarGames.Scripts.Factories;
using Test_NinsarGames.Scripts.Tools;
using Test_NinsarGames.Scripts.UI;
using UnityEngine;
using Zenject;

namespace Test_NinsarGames.Scripts.Gameplay
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] private string fileName;
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private GridText uiController;

        private Vector2Int _position = new Vector2Int(1, 1);
        private char[,] _grid;
        private IGameObjectCreator _gameObjectCreator;

        [Inject]
        private void Construct(IGameObjectCreator gameObjectCreator)
        {
            _gameObjectCreator = gameObjectCreator;
        }

        void OnEnable()
        {
            InitializeGridFromFile();
        }

        private void InitializeGridFromFile()
        {
            var fileReader = new FileReader(fileName);
            string[] lines = fileReader.ReadFile();
            if (lines.Length > 0)
            {
                Vector2Int randomPosition = GetRandomPosition(lines);
                InitializeGrid(lines, randomPosition);
            }
        }

        public void InitializeGrid(string[] lines, Vector2Int startPosition)
        {
            int rows = lines.Length;
            int cols = lines[0].Length;
            _grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    _grid[i, j] = lines[i][j];
                }
            }

            _position = startPosition;
            UpdateGrid();
        }

        public void UpdateGrid()
        {
            ClearOldGrid();
            CreateNewGrid();
            uiController.UpdateGridText(_grid, _position);
        }

        private void ClearOldGrid()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        private void CreateNewGrid()
        {
            int rows = _grid.GetLength(0);
            int cols = _grid.GetLength(1);

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int x = (_position.x + j + cols) % cols;
                    int y = (_position.y + i + rows) % rows;
                    _gameObjectCreator.PrimitiveFactory(cubePrefab, _grid[y, x], new Vector3(j, -i, 0), transform);
                }
            }
        }

        public void Move(Vector2Int direction)
        {
            _position.x = (_position.x + direction.x + _grid.GetLength(1)) % _grid.GetLength(1);
            _position.y = (_position.y - direction.y + _grid.GetLength(0)) % _grid.GetLength(0);

            UpdateGrid();
        }

        private Vector2Int GetRandomPosition(string[] lines)
        {
            int rows = lines.Length;
            int cols = lines[0].Length;
            int randomRow = UnityEngine.Random.Range(0, rows);
            int randomCol = UnityEngine.Random.Range(0, cols);
            return new Vector2Int(randomCol, randomRow);
        }
    }
}
