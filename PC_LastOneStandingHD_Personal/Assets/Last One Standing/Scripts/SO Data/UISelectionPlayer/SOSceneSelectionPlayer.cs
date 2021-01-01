using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "InfoPlayer#", menuName = "SO_Player/InfoPlayer")]
public class SOSceneSelectionPlayer : ScriptableObject
{
    [SerializeField] internal string namePlayer;
    [TextArea(0,500)]
    [SerializeField] internal string descriptionPlayer;
    [Space(20)]
    [SerializeField] internal Sprite skillSpecial;
    [SerializeField] internal Sprite skillOne;
    [SerializeField] internal Sprite skillTwo;

    [Space(20)]
    [TextArea(0, 100)]
    [SerializeField] internal string[] infoSkill;

    [Space(20)]
    [SerializeField] internal bool isDamageSkillSpecial;
    [SerializeField] internal string[] damageSkill;

}

