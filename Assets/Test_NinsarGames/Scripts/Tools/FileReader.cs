using System;
using System.IO;
using Test_NinsarGames.Scripts.Gameplay;
using UnityEngine;

namespace Test_NinsarGames.Scripts.Tools
{
    public class FileReader
    {
        private string _filePath;
        public FileReader(string fileName)
        {
            _filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        }
        public string[] ReadFile()
        {
            try
            {
                return File.ReadAllLines(_filePath);
            }
            catch (FileNotFoundException e)
            {
                Debug.LogError("File not found: " + _filePath + "\nException: " + e.Message);
                return new string[0];
            }
            catch (Exception e)
            {
                Debug.LogError("An error occurred while reading the file: " + e.Message);
                return new string[0];
            }
        }

    }
}
