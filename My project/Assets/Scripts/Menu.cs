using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("GameManager")]
    public GameManager _gameManager; //arrastar o Game Manager no inspetor

    public void Play()
    {
        _gameManager.Enable();
        Destroy(gameObject);
    }
}
