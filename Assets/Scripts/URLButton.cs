using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLButton : MonoBehaviour
{
    /// <summary>
    /// Abrir URL especificado usando browser
    /// </summary>
    /// <param name="url">URL a abrir</param>
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
