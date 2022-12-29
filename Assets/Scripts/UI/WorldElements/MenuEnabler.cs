using UnityEngine;

public class MenuEnabler : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    private void OnTriggerEnter(Collider other)
    {
        _menu.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _menu.gameObject.SetActive(false);
    }
}
