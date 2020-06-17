using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : MonoBehaviour
{
    [SerializeField] internal GameObject[] onOffObject;
    [SerializeField] internal Image[] iconChangeColor;
    [SerializeField] internal Color[] colorIcon;

    public void EnterButton(int index)
    {
        for (int i = 0; i < onOffObject.Length; i++)
        {
            onOffObject[index].SetActive(true);
            onOffObject[i].SetActive(false);

            iconChangeColor[index].color = colorIcon[0];
            iconChangeColor[i].color = colorIcon[1];
        }
        
    }
}
