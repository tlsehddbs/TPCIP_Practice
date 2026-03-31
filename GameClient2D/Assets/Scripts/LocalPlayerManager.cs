using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LocalPlayerManager : MonoBehaviour
{
    public GameObject slots1;
    public GameObject slots2;
    public GameObject slots3;
    public GameObject slots4;
    public GameObject slots5;

    public Sprite coin;
    public PlayerManager pm;

    private void FixedUpdate()
    {
        if (pm.itemCount == 1)
        {
            slots1.GetComponent<Image>().sprite = coin;
        }
        if (pm.itemCount == 2)
        {
            slots2.GetComponent<Image>().sprite = coin;
        }
        if (pm.itemCount == 3)
        {
            slots3.GetComponent<Image>().sprite = coin;
        }
        if (pm.itemCount == 4)
        {
            slots4.GetComponent<Image>().sprite = coin;
        }
        if (pm.itemCount == 5)
        {
            slots5.GetComponent<Image>().sprite = coin;
        }
    }
}
