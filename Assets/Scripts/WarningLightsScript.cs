using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningLightsScript : MonoBehaviour
{
    [SerializeField] Values value;
    [SerializeField] Transform Entity, player;
    float dangerlevel = 10f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(Vector3.Distance(player.position, Entity.position)) < dangerlevel & Entity.gameObject.activeSelf)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
