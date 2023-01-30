using System.Collections.Generic;
using UnityEngine;

namespace UI.MainMenu
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _charactersList;

        public int CharactersCount => _charactersList.Count;

        public void SetCharacter(int index)
        {
            foreach (var character in _charactersList)
            {
                character.SetActive(false);
            }

            _charactersList[index].SetActive(true);
        }
    }
}
