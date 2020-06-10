using UnityEngine;
using UnityEngine.SceneManagement;
internal enum ModeGame
{
    start,
    selectionPlayer,
    lobby,
    gamePlay,
    gameOver
}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] internal SOGameManager sOGameManager;
    [SerializeField] internal ModeGame modeGame;

    [Space(10)]
    [SerializeField] internal GameObject playerAdd;
    private GameObject instancePlayer_GM;

    private void Awake()
    {
        if (!instance)
            instance = FindObjectOfType<GameManager>();
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        if(modeGame == ModeGame.gamePlay)
            SceneManager.LoadSceneAsync("SceneUIGame", LoadSceneMode.Additive);
    }
    private void Update()
    {
        InstancePlayer();
    }

    private void InstancePlayer()
    {
        if(modeGame == ModeGame.lobby && !instancePlayer_GM)
        {
            instancePlayer_GM = Instantiate(sOGameManager.playerInstance);
            instancePlayer_GM.transform.parent = transform;
            playerAdd = transform.GetChild(0).gameObject;
        }
    }
}
