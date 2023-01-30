using System;
using UnityEngine;

namespace UI.MainMenu
{
    [Serializable]
    public class MenuModel
    {
        [SerializeField] private string _gameScene;

        public int CurrentCharacterIndex { get; set; }

        public string GameScene => _gameScene;
    }
}
