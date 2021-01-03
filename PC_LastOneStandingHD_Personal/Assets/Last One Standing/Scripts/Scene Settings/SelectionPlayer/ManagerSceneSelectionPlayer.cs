using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerSceneSelectionPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] internal SOSceneSelectionPlayer[] sOInfoPlayer;
    
    [Space(15)]
    [SerializeField] internal TextMeshProUGUI namePlayer;
    [SerializeField] internal TextMeshProUGUI descriptionPlayer;
    [SerializeField] internal TextMeshProUGUI infoSkill;

    [Space(15)]
    [SerializeField] internal Image skillSpecial;
    [SerializeField] internal Image skillOne;
    [SerializeField] internal Image skillTwo;

    private int refIndex;
    public void EnablePlayer(int index)
    {
        refIndex = index;
        GameManager.instance.sOGameManager.indexPlayer = index;

        for (int i = 0; i < players.Length; i++)
        {
            players[index].SetActive(true);
            players[i].SetActive(false);

            namePlayer.text = sOInfoPlayer[index].namePlayer;
            descriptionPlayer.text = sOInfoPlayer[index].descriptionPlayer;

            skillSpecial.sprite = sOInfoPlayer[index].skillSpecial;
            skillOne.sprite = sOInfoPlayer[index].skillOne;
            skillTwo.sprite = sOInfoPlayer[index].skillTwo;
        }

        GameManager.instance.sOGameManager.playerInstance = GameManager.instance.sOGameManager.playerContent[index];
        GameManager.instance.sOGameManager.sOSceneSelectionPlayer = sOInfoPlayer[index];
    }

    public void DescriptionSkill(int index)
    {
        if(sOInfoPlayer[refIndex].isDamageSkillSpecial)
        {
            infoSkill.text = sOInfoPlayer[refIndex].infoSkill[index] + "\n" + "\n" + "<b>Damage:</b> " + sOInfoPlayer[refIndex].damageSkill[index];
        }
        else if (!sOInfoPlayer[refIndex].isDamageSkillSpecial)
        {
            infoSkill.text = sOInfoPlayer[refIndex].infoSkill[index] + "\n" + "\n" + sOInfoPlayer[refIndex].damageSkill[index];
        }

    }

    public void StartGame()
    {
        GameManager.instance.modeGame = ModeGame.lobby;
        SceneManager.LoadScene("SceneLobby");

        GameManager.instance.InstancePlayer();
        GameManager.instance.sOGameManager.isSceneSelectionPlayer = false;
    }
}
