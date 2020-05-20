using UnityEngine;

internal enum ModeGame
{
    lobby,
    gamePlay,
    gameOver
}
public class GameManager : MonoBehaviour
{
    [SerializeField] internal ModeGame modeGame;
}
