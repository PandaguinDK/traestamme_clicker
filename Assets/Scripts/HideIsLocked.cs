using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideIsLocked : MonoBehaviour
{

    public Image TræstammePrisBGIsLocked;
    public Image BagerPrisBGIsLocked;
    public Image FactoryPrisBGIsLocked;
    public Image PrestigePrisBGIsLocked;

    private Image[] images;

    bool[] isLocked;

    void Update()
    {
        images = new Image[] { TræstammePrisBGIsLocked, BagerPrisBGIsLocked, FactoryPrisBGIsLocked, PrestigePrisBGIsLocked };
        isLocked = new bool[] { TræstammeScript.træstammeIsLocked, BagerScript.bagerIsLocked, FactoryScript.factoryIsLocked, PrestigeScript.prestigeIsLocked};

        ImageIsLocked();
    }


    void ImageIsLocked()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (isLocked[i] == true)
            {
                images[i].enabled = true;
            }
            else
            {
                images[i].enabled = false;
            }
        }
    }
}
