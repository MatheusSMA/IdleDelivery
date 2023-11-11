using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers Instance;

    [SerializeField] private GameManager _gameManager;
    [SerializeField] private MotoboyManager _motoboyManager;

    public GameManager GameManager { get => _gameManager; set => _gameManager = value; }
    public MotoboyManager MotoboyManager { get => _motoboyManager; set => _motoboyManager = value; }

    private void Awake()
    {
        Instance = this;
    }
}