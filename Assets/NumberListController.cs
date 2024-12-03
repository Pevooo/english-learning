using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Text = UnityEngine.UI.Text;

public class NumberListController : MonoBehaviour
{
    public Button NextButton;
    public Button BackButton;
    public Button AudioPlayButton;
    public Text DisplayText;
    private int displayIndex = 0;
    private List<string> Numbers = new List<string>{ "1", "2", "3", "4", "5", "6", "7", "8", "9" };
    private List<string> NumbersWords = new List<string> { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
    // Start is called before the first frame update
    void Start()
    {


        DisplayText.text = getDisplayText();

        BackButton.enabled = false;
        NextButton.onClick.AddListener(() =>
        {
            displayIndex++;
            DisplayText.text = getDisplayText();
            Debug.Log("sss");

            if (displayIndex == Numbers.Count - 1)
            {
                NextButton.enabled = false;
            }
            else
            {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });

        BackButton.onClick.AddListener(() =>
        {
            displayIndex--;
            DisplayText.text = getDisplayText();


            if (displayIndex == 0)
            {
                BackButton.enabled = false;
            }
            else
            {
                BackButton.enabled = true;
                NextButton.enabled = true;
            }
        });

      
    }

    // Update is called once per frame
    void Update()
    {

    }
    string getDisplayText() {
        return Numbers[displayIndex].ToString() +" "+ NumbersWords[displayIndex].ToString();
    }
   
}
