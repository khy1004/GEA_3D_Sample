using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : MonoBehaviour
{
    public DialogueDataSO myDialogue;
    private DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();

        if(dialogueManager == null)
        {
            Debug.LogError("���̾�α� �Ŵ����� �����ϴ�.");
        }
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (dialogueManager == null) return;
        if (dialogueManager.lsDialogueActive()) return;
        if (myDialogue == null) return;
        dialogueManager.StartDialogue(myDialogue);
    }
}
