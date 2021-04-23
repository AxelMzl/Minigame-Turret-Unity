using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loader : MonoBehaviour
{
    public int SceneindexToLoad = 1;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneindexToLoad);
    }
}
