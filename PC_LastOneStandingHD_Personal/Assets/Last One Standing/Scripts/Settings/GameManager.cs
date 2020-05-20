using UnityEngine;

internal enum ModeGame
{
    lobby,
    gamePlay,
    gameOver
}
public class GameManager : MonoBehaviour
{
    internal static GameManager gameManager;
    public static GameManager instance
    {
        get
        {
            if(!gameManager)
            {
                gameManager = FindObjectOfType<GameManager>();

                if(!gameManager)
                {
                    var singleton = new GameObject(typeof(GameManager).ToString());
                    gameManager = singleton.AddComponent<GameManager>();
                }
            }
            return gameManager;
                
        }
    }

    [SerializeField] internal ModeGame modeGame;
}
