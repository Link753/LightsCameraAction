using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    [SerializeField] GameObject[] DisableAndAnimate;
    [SerializeField] Animator[] Animators;
    // Start is called before the first frame update

    IEnumerator Wait(float waittime)
    {
        yield return new WaitForSeconds(waittime);
        SceneManager.LoadScene(0);
        Debug.Log("Waiting");
    }

    void Start()
    {
        Debug.Log("Ending");
        foreach(GameObject g in DisableAndAnimate)
        {
            if (g.GetComponent<MonoBehaviour>())
            {
                g.GetComponent<MonoBehaviour>().enabled = false;
            }
            g.GetComponent<Transform>().localRotation = Quaternion.Euler(Vector3.zero);
        }

        Animators[0].SetBool("IsEnding", true);
        Animators[1].SetBool("IsBeingStabbed", true);
        Animators[0].SetBool("isStabbed", true);
        Animators[2].SetBool("IsAfterPlayer", true);
        StartCoroutine(Wait(5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
