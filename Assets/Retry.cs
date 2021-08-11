using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
    private string _sceneName;
    // Start is called before the first frame update
    void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;   
    }

    void OnCollisionEnter()
    {
        StartCoroutine(Restart());
    }

    IEnumerator Restart()
    {
        //yield return new WaitForSeconds(2);
        yield return 0;
        SceneManager.LoadScene(_sceneName);
    }
}
