using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerSceneSelectionPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] internal SOInfoPlayerUI[] sOInfoPlayer;
    [Space(15)]
    [SerializeField] internal TextMeshProUGUI textStart;
    [Space(15)]
    [SerializeField] internal Image iconPlayer;
    [SerializeField] internal TextMeshProUGUI namePlayer;
    [SerializeField] internal TextMeshProUGUI descriptionPlayer;

    private void Awake()
    {
        textStart.fontSizeMax = 35;
        textStart.text = "Selection Player";
    }

    //Button Left Selection Player
    public void EnablePlayer(int index)
    {
        GameManager.instance.sOGameManager.indexPlayer = index;
        textStart.fontSizeMax = 50;
        textStart.text = "Start";

        for (int i = 0; i < players.Length; i++)
        {
            players[index].SetActive(true);
            players[i].SetActive(false);

            iconPlayer.sprite = sOInfoPlayer[index].iconPlayer;
            namePlayer.text = sOInfoPlayer[index].namePlayer;
            descriptionPlayer.text = sOInfoPlayer[index].descriptionPlayer;
        }
        GameManager.instance.sOGameManager.playerInstance = GameManager.instance.sOGameManager.playerContent[index];
    }

    //Button Start Game
    public void StartGame(int index)
    {
        GameManager.instance.modeGame = ModeGame.lobby;
        SceneManager.LoadScene("SceneLobby");

        GameManager.instance.InstancePlayer();
        GameManager.instance.sOGameManager.isSceneSelectionPlayer = false;
        
    }
   
        
}
