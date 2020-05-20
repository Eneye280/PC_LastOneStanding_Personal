using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "ParameterPlayer#", menuName = "SO_Player")]
public class ScriptablePlayer : ScriptableObject
{
    [SerializeField] internal Sprite spritePlayer;
    [SerializeField] internal GameObject objectPlayer;
    [SerializeField] internal Animator animPlayer;

    [Header("Parameter's Player")]
    [Space(10)]
    [SerializeField] internal string namePlayer;
    [SerializeField] internal float speedPlayer;

    [SerializeField] internal Vector2 directionPlayer;
    [SerializeField] internal Vector3 movementPlayer;

    [Space(10)]
    [SerializeField] internal float horizontal;
    [SerializeField] internal float vertical;
}
