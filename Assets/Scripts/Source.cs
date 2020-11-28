using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{
    public string URL;
    public void Redirrect()
    {
        Application.OpenURL(URL);
    }
}
