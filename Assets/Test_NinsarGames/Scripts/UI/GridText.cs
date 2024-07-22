using UnityEngine;
using UnityEngine.UI;

namespace Test_NinsarGames.Scripts.UI
{
    public class GridText : MonoBehaviour
    {
        [SerializeField] private Text gridText;

        public void UpdateGridText(char[,] grid, Vector2Int position)
        {
            string text = "";
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                text += GetRowText(grid, position, i, cols, rows) + "\n";
            }

            gridText.text = text;
        }

        private string GetRowText(char[,] grid, Vector2Int position, int row, int cols, int rows)
        {
            string rowText = "";

            for (int j = 0; j < cols; j++)
            {
                bool isHighlighted = IsCellHighlighted(position, j, row, cols, rows);
                rowText += isHighlighted ? $"<color=white>{grid[row, j]}</color>" : grid[row, j].ToString();
            }

            return rowText;
        }

        private bool IsCellHighlighted(Vector2Int position, int col, int row, int cols, int rows)
        {
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    int checkX = (position.x + x + cols) % cols;
                    int checkY = (position.y + y + rows) % rows;

                    if (row == checkY && col == checkX)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
