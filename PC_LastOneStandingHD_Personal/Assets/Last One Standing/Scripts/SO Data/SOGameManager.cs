using UnityEngine;

[CreateAssetMenu(fileName = "GameManager", menuName = "SOGameManager")]
public class SOGameManager : ScriptableObject
{
    [SerializeField] internal bool isSceneSelectionPlayer;
    [SerializeField] internal int indexPlayer;

    [Space(10)]
    [SerializeField] internal GameObject[] playerContent;
    [SerializeField] internal GameObject playerInstance;
}
