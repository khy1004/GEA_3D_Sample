using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/DialogueData")]
public class DialogueDataSO : ScriptableObject
{

    [Header("ĳ���� ����")]
    public string characterName = "ĳ����";
    public Sprite characterlmage;


    [Header("��ȭ ����")]
    [TextArea(3, 10)]
    public List<string> diaiogueLines = new List<string>();
    // Start is called before the first frame update

}
