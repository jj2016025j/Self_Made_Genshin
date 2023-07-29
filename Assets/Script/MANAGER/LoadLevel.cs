using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour//載入場景
{
    public void opensence(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
