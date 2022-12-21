using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenuModel _model;
    [SerializeField] private MenuView _view;

    public void StartGame()
    {
        SceneManager.LoadScene(_model.GameScene);
    }

    public void Exit()
    {
        Debug.Log("Выйти из игры");
    }

    public void RateUs()
    {
        Debug.Log("Поставил 5 звёзд");
    }

    public void ChangeCharacter(int value)
    {
        int currentValue = _model.CurrentCharacterIndex + value;

        if (currentValue < 0)
        {
            currentValue = _view.CharactersCount - 1;
        }
        else if (currentValue >= _view.CharactersCount)
        {
            currentValue = 0;
        }

        _model.CurrentCharacterIndex = currentValue;
        _view.SetCharacter(currentValue);
    }
}
