using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    public GameObject popup;

    public void OnStartPress()
    {
        SceneManager.LoadScene("PoolFinal", LoadSceneMode.Single);
    }

    public void OnSettingsPress()
    {
        popup.SetActive(!popup.activeSelf);
    }
}
