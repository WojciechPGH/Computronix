using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text text;
    public Image panel;
    public GameObject triggerObject;
    [Range(0f, 1f)]
    public float panelAlpha = 0.7f;

    private void Start()
    {
        TriggerText(0);
        CreateTriggerPoint(1, new Vector2(1.5f, 0f));
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void TriggerText(int ID)
    {
        StopAllCoroutines();
        text.gameObject.SetActive(true);
        panel.material.color = new Color(0, 0, 0, panelAlpha);
        text.color = new Color(1, 1, 1, 1);
        text.text = GetText(ID);
        StartCoroutine(FadeOut(5f));
    }

    private void CreateTriggerPoint(int triggerID, Vector2 pos)
    {
        GameObject obj = Instantiate(triggerObject);
        obj.transform.position = pos;
        obj.GetComponent<TextTrigger>().triggerID = triggerID;
    }

    private string GetText(int textID)
    {
        switch (textID)
        {
            case 0: return "OTO I JEST! PIRAMIDA KU CZCI COMPUTRONIXA! BOSTWO GIER I ZABAW.";
            case 1: return "HIEROGLIFY MOWIA, ZE PIRAMIDA JEST NAJERZONA PULAPKAMI, POWINIENEM UWAZAC POD NOGI...";
            case 2: return "CIEKAWE... NA SCIANACH UKAZANA JEST HISTORIA CHLOPCA, KTORY STRACIL NAJCENNIEJSZA ZABAWKE.";
            case 3: return "CHLOPIEC MODLIL SIE DO BOSTWA Z PROSBA O NAPRAWIENIE WYRZADZANYCH MU KRZYWD.";
            case 4: return "BOSTWO POSTANOWILO POMOC CHLOPCU, ALE MUSIAL ON PRZEJSC TEST. A WIEC STAD TE WSZYSTKIE PULAPKI...";
            case 5: return "UPORAWSZY SIE Z ZADANIAMI PRZED CHLOPCEM ZOSTAL OSTATNI SPRAWDZIAN... WYBOR ZABAWKI.";
            case 6: return "MOGL WYBRAC NAJPIEKNIEJSZA ZABAWKE POD SLONCEM... LECZ ON WYBRAL TAKA, KTORA W ZUPELNOSCI SPELNIALA JEGO OCZEKIWANIA.";
        }
        return "";
    }

    private IEnumerator FadeOut(float time2Read)
    {
        yield return new WaitForSeconds(time2Read);
        Color panelColor = Color.black;
        Color textColor = Color.white;
        for (float f = panelAlpha; f >= 0; f -= (panelAlpha * 0.05f))
        {
            panelColor.a = textColor.a = f;
            panel.material.color = panelColor;
            text.color = textColor;
            yield return new WaitForSeconds(.1f);
        }
        text.gameObject.SetActive(false);
    }
}
