using Player;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public float Gems;
    public float PlayerDamage;
    public float PlayerMoveSpeed;

    public static SaveData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            PlayerPrefs.SetFloat("Gems", Gems);
        }
        else
        {
            Destroy((gameObject));
        }
    }
}