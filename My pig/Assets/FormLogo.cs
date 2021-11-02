using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FormLogo : MonoBehaviour
{
    [SerializeField]public string c;
    [SerializeField] Color c2;
    [SerializeField] GameObject[] sprites;
    [SerializeField] GameObject[] sprites2;
    [SerializeField] internal int layer = 1;
    [SerializeField] internal int player=0;[SerializeField]
    internal int player2 = 0;
    internal Stand stand;
    [SerializeField] int btn;
    public void SetForm()
    {
        if (FindObjectOfType<StandControl>().LoadPage()==0) {
            if (player == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (sprites[i].GetComponent<Form_>().operation1() == c) { return; }
                }
            }
            if (player == 1)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (sprites2[i].GetComponent<Form_>().operation1() == c) { return; }
                }
            }
            sprites[layer].GetComponent<Form_>().operation2(c);
            sprites2[layer].GetComponent<Form_>().operation2(c);
        }
        else {
            if (player2 == 0)
            {
                for (int i = 4; i < 7; i++)
                {
                    if (sprites[i].GetComponent<Logo>().operation1() == c) { return; }
                }
            }
            if (player2 == 1)
            {
                for (int i = 4; i < 7; i++)
                {
                    if (sprites2[i].GetComponent<Logo>().operation1() == c) { return; }
                }
            }
            sprites[layer].GetComponent<Logo>().operation2(c); 
            sprites2[layer].GetComponent<Logo>().operation2(c); 
        }
        stand.setColor(sprites[layer].GetComponent<SpriteRenderer>(), c);
        stand.setColor(sprites2[layer].GetComponent<SpriteRenderer>(), c);
    }
    // Use this for initialization
    void Start()
    {
        player = 0;
        if (tag == "color") {
            //c = FindObjectOfType<StandControl>().getColors(); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (stand != null) { stand.SetImageColor(GetComponent<Image>(),c); }
        else{ }
        if (tag == "color")
        {
            if (FindObjectOfType<StandControl>().LoadPage() == 0)
            {
                stand = new Stand(); 
                stand.SetImageColor(GetComponent<Image>(), c);
            }
            if (FindObjectOfType<StandControl>().LoadPage() == 1)
            {
                stand = new Stand();
                stand.SetImageColor(GetComponent<Image>(), c);
            }
        }
    }
}