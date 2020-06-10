using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "InfoPlayer#", menuName = "SO_Player/InfoPlayer")]
public class SOInfoPlayerUI : ScriptableObject
{
    [SerializeField] internal Sprite iconPlayer;
    [SerializeField] internal string namePlayer;
    [TextArea(0,500)]
    [SerializeField] internal string descriptionPlayer;
    [Space(20)]
    [SerializeField] internal string habilityPlayer;
}

