using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public int triggerID = -1;
    public TextController textController;

    private void Start()
    {
        textController = GameObject.FindGameObjectWithTag("GameController").GetComponent<TextController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            textController.TriggerText(triggerID);
        }
        gameObject.SetActive(false);
    }
}
