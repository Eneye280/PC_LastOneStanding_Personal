using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "ParameterPlayer#", menuName = "SO_Player/InGamePlay")]
public class SOPlayer : ScriptableObject
{
    [SerializeField] internal Sprite spritePlayer;
    [SerializeField] internal GameObject objectPlayer;
    [SerializeField] internal Animator animPlayer;

    [Header("Parameter's Player")]
    [Space(10)]
    [SerializeField] internal string namePlayer;

    [Range(0,10)]
    [SerializeField] internal float speedPlayerMovement;

    [Range(0,500)]
    [SerializeField] internal float speedPlayerRotation;

    [SerializeField] internal Vector2 directionPlayer;
    [SerializeField] internal Vector3 movementPlayer;

    [Space(10)]
    [SerializeField] internal float horizontal;
    [SerializeField] internal float vertical;

}
