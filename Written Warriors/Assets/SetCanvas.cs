using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SetCanvas : MonoBehaviour
{
    public Image screen;
    
    public Image P1Image;
    public Image P2Image;

    public TextMeshProUGUI P1Name;
    public TextMeshProUGUI P2Name;

    public TextMeshProUGUI P1NameBG;
    public TextMeshProUGUI P2NameBG;

    public TextMeshProUGUI P1Title;
    public TextMeshProUGUI P2Title;

    public TextMeshProUGUI P1TitleBG;
    public TextMeshProUGUI P2TitleBG;

    Character P1;
    Character P2;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        P2 = Resources.Load<Character>(FindObjectOfType<GameManager>().PathP2);
        P1 = Resources.Load<Character>(FindObjectOfType<GameManager>().PathP1);

        P1Image.sprite = P1.Face;
        P2Image.sprite = P2.Face;

        P1Name.text = P1.CharName.ToUpper();
        P2Name.text = P2.CharName.ToUpper();

        P1NameBG.text = P1.CharName.ToUpper();
        P2NameBG.text = P2.CharName.ToUpper();
        StartCoroutine(Wait());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        yield return StartCoroutine(GM.FadeScreenOut(screen));
        SceneManager.LoadScene(1);
    }

}
