using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameend : MonoBehaviour
{
    public void gotoend()
    {
        Application.Quit();

        //�׽�Ʈ��
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
