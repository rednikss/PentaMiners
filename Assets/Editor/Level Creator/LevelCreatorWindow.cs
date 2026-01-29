using System;
using System.IO;
using App.Scripts.Game.Level.Initialization.Config;
using App.Scripts.Game.Level.Initialization.Config.Blocks;
using UnityEditor;
using UnityEngine;
using Newtonsoft.Json;

namespace Editor.Level_Creator
{
    public class LevelCreatorWindow : EditorWindow
    {
        private LevelBlockConfig _levelBlockConfig;

        private LevelConfig _levelData;
        
        
        private Vector2Int _maxGridSize = new(10, 10);
        
        private Vector2Int _gridSize = new(5, 5);
        
        
        private string _levelPath = "Assets/Resources/Level";
        
        private int _levelNumber;
        
        
        [MenuItem("Tools/Level Creator")]
        private static void OpenWindow()
        {
            var wnd = GetWindow<LevelCreatorWindow>(true, "Level Creator", true);
            wnd.minSize = wnd.maxSize = new(600, 450);
        }

        private void CreateGUI()
        {
            _levelData = new LevelConfig(_gridSize);
        }

        private void OnGUI()
        {
            CreateOptions();
            
            EditorGUILayout.Space(25);
            
            CreateGrid();
            
            EditorGUILayout.Space(25);
            
            CreateSavePanel();
        }

        private void CreateOptions()
        {
            _levelBlockConfig = (LevelBlockConfig) EditorGUILayout.ObjectField("Blocks Config", 
                _levelBlockConfig, typeof(LevelBlockConfig), false);
            
            _gridSize.x = EditorGUILayout.IntField("Grid width", _gridSize.x);
            
            _gridSize.y = EditorGUILayout.IntField("Grid height", _gridSize.y);

            _gridSize.x = Math.Clamp(_gridSize.x, 1, _maxGridSize.x);
            _gridSize.y = Math.Clamp(_gridSize.y, 1, _maxGridSize.y);
            
            if (GUILayout.Button("Reset")) CreateGUI();
        }

        private void CreateGrid()
        {
            ResizeGrid(_gridSize);
            
            GUILayout.BeginVertical();
            for (var i = 0; i < _gridSize.x; i++)
            {
                GUILayout.BeginHorizontal();
                for (var j = 0; j < _gridSize.y; j++)
                {
                    _levelData.Blocks[i, j] = EditorGUILayout.IntField(_levelData.Blocks[i, j]);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndVertical();
            
            EditorGUILayout.Space(5);
            
            _levelData.TickSpeed = EditorGUILayout.FloatField("Level speed", _levelData.TickSpeed);
            _levelData.TickSpeed = Math.Clamp(_levelData.TickSpeed, 0.2f, 5);
        }

        private void ResizeGrid(Vector2Int newSize)
        {
            var newGrid = new int[newSize.x, newSize.y];
            
            var minWidth = Math.Min(_levelData.GetWidth(), newSize.x);
            var minHeight = Math.Min(_levelData.GetHeight(), newSize.y);
            
            for (int i = 0; i < minWidth; i++)
            {
                for (int j = 0; j < minHeight; j++)
                {
                    newGrid[i, j] = _levelData.Blocks[i, j];
                }
            }

            _levelData.Blocks = newGrid;
        }
        
        private void CreateSavePanel()
        {
            _levelPath = EditorGUILayout.TextField("Saving Path", _levelPath);
            _levelNumber = Math.Max(0, EditorGUILayout.IntField("Level number",_levelNumber));

            EditorGUILayout.Space(10);
            
            if (GUILayout.Button("Save to .json")) SaveLevel(_levelData);
        }

        private void SaveLevel(LevelConfig levelData)
        {
            var serializedObject = JsonConvert.SerializeObject(levelData, Formatting.Indented);
            var path = Path.Combine(_levelPath, $"{_levelNumber.ToString()}.json");

            File.WriteAllText(path, serializedObject);
            
            Debug.Log("Level created successfully!");
        }
    }
}