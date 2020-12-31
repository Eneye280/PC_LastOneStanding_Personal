using UnityEngine;
using UnityEngine.UI;

public class EnableDisableObjectsUI : MonoBehaviour
{
    [SerializeField] internal bool isDoubleVerifycation;
    [SerializeField] internal int count;
    [SerializeField] internal EnableDisableObjectsUI[] otherDisableVerification;
    
    [Space(15)]
    [SerializeField] internal GameObject[] objectEnableDisable;
    [SerializeField] internal Image[] iconChangeColor;
    [SerializeField] internal Color[] colorIcon;

    public void AddFuctionOnOff(int index)
    {
        if (isDoubleVerifycation)
        {
            count += 1;

            for (int i = 0; i < otherDisableVerification.Length; i++)
            {
                otherDisableVerification[i].count = 0;
            }

            if (count == 1)
            {
                for (int i = 0; i < objectEnableDisable.Length; i++)
                {
                    objectEnableDisable[index].SetActive(true);
                    objectEnableDisable[i].SetActive(false);

                    iconChangeColor[index].color = colorIcon[0];
                    iconChangeColor[i].color = colorIcon[1];
                }
            }
            if (count == 2)
            {
                for (int i = 0; i < objectEnableDisable.Length; i++)
                {
                    objectEnableDisable[index].SetActive(false);
                    objectEnableDisable[i].SetActive(false);

                    iconChangeColor[index].color = colorIcon[1];
                    iconChangeColor[i].color = colorIcon[1];

                    count = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i < objectEnableDisable.Length; i++)
            {
                objectEnableDisable[index].SetActive(true);
                objectEnableDisable[i].SetActive(false);

                iconChangeColor[index].color = colorIcon[0];
                iconChangeColor[i].color = colorIcon[1];
            }
        }
 
        
    }
}
