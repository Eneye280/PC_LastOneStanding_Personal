using UnityEngine;
using UnityEngine.UI;

public class EnableDisableObjectsUI : MonoBehaviour
{
    [Header("VERIFY DOUBLE SELECTION")]
    [SerializeField] internal bool isDoubleVerifycation;
    [SerializeField] internal int count;
    [SerializeField] internal EnableDisableObjectsUI[] otherDisableVerification;

    [Header("OBJECTS ENABLE AND DISABLE")]
    [SerializeField] internal GameObject[] objectEnable;
    [SerializeField] internal GameObject[] objectDisable;

    [Header("ICON CHANGE COLOR")]
    [SerializeField] internal Image[] iconColorChangeToOrange;
    [SerializeField] internal Image[] iconColorChangeToWhite;

    [Header("COLOR BUTTON'S")]
    [SerializeField] internal Color[] colorIcon;

    [Header("FUNCTIONS ADDITIONAL")]
    [SerializeField] internal bool isFunctionAdttional;
    [SerializeField] internal GameObject[] objectEnableAdditional;
    [SerializeField] internal Image[] iconColorChangeToOrangeAdditional;
    [SerializeField] internal EnableDisableObjectsUI[] otherDisableVerificationAdditional;

    public void AddFuctionOnOff()
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
                for (int i = 0; i < objectEnable.Length; i++)
                {
                    objectEnable[i].SetActive(true);
                }
                for (int i = 0; i < iconColorChangeToOrange.Length; i++)
                {
                    iconColorChangeToOrange[i].color = colorIcon[0];
                }
                for (int i = 0; i < iconColorChangeToWhite.Length; i++)
                {
                    iconColorChangeToWhite[i].color = colorIcon[1];
                }
                for (int i = 0; i < objectDisable.Length; i++)
                {
                    objectDisable[i].SetActive(false);
                }
            }
            if (count == 2)
            {
                for (int i = 0; i < objectEnable.Length; i++)
                {
                    objectEnable[i].SetActive(false);
                    iconColorChangeToOrange[i].color = colorIcon[1];

                    if (isFunctionAdttional)
                    {
                        for (int j = 0; j < objectEnableAdditional.Length; j++)
                        {
                            objectEnableAdditional[j].SetActive(true);
                        }
                        for (int l = 0; l < iconColorChangeToOrangeAdditional.Length; l++)
                        {
                            iconColorChangeToOrangeAdditional[l].color = colorIcon[0];
                        }
                        for (int y = 0; y < otherDisableVerificationAdditional.Length; y++)
                        {
                            otherDisableVerificationAdditional[y].count = 1;
                        }
                    }

                    count = 0;
                }
            }
        }
        else
        {
            for (int i = 0; i < objectEnable.Length; i++)
            {
                objectEnable[i].SetActive(true);
            }
            for (int i = 0; i < iconColorChangeToOrange.Length; i++)
            {
                iconColorChangeToOrange[i].color = colorIcon[0];
            }
            for (int i = 0; i < iconColorChangeToWhite.Length; i++)
            {
                iconColorChangeToWhite[i].color = colorIcon[1];
            }
            for (int i = 0; i < objectDisable.Length; i++)
            {
                objectDisable[i].SetActive(false);
            }
        }



    }
}
