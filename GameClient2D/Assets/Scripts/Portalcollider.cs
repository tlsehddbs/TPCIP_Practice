using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portalcollider : MonoBehaviour
{
    public GameObject FinishUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("°¨Áö");
        if (collision.gameObject.GetComponent<PlayerManager>().itemCount == 5)
        {
            FinishUI.SetActive(true);
        }
    }
}
