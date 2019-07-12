using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    int hearts;
    public GameObject heartPrefab;
    public float heartOffset = 64f;
    GameObject[] heartObjects;
    Vector2 startPos;

    private void Start()
    {
        CreateLife(PlayerController.life);
    }

    public void CreateLife(int numOfLife)
    {
        startPos = new Vector2(10f, -10f);
        hearts = numOfLife;
        heartObjects = new GameObject[numOfLife];
        for (int i = 0; i < hearts; i++)
        {
            heartObjects[i] = Instantiate(heartPrefab, transform);
            heartObjects[i].GetComponent<RectTransform>().anchoredPosition = startPos + Vector2.right * heartOffset * i;
        }
    }

    public void RemoveLife()
    {
        hearts--;
        heartObjects[hearts].gameObject.SetActive(false);
    }
}
