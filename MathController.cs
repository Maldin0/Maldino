using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MathController : MonoBehaviour
{
    // Start is called before the first frame update
    private float a, b;
    private float answer;
    public Text valueA, valueB, scoretxt;
    private float localofAnswer;//Answers location
    public int score;
    public GameObject[] choiceBtn;//Get choice button from Unity
    public string tagBtn;//Tell which choice is correct or wrong
    public static MathController instance;

    private void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        AdditionMethod();
    }

    // Update is called once per frame
    void Update()
    {
        tagBtn = localofAnswer.ToString();
        scoretxt.text = "" + score;
    }
    //Creat function to random numbers and plus them together
    public void AdditionMethod()
    {
        a = Random.Range(0, 21);//min,max (0-21)
        b = Random.Range(0, 21);
        valueA.text = "" + a;
        valueB.text = "" + b;
        answer = a + b;
        Debug.Log(answer);

        //random correct answers location
        localofAnswer = Random.Range(0,choiceBtn.Length);//location of correct answer

        //Loop choice
        for (int i=0;i<choiceBtn.Length;i++)
        {
            //to change number in button
            //put correct answer in
            if (i==localofAnswer)
            {
                //put correct answer in Text of button
                choiceBtn[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {
                //put wrong answer in Text of other button
                choiceBtn[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 41);
                while (choiceBtn[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    choiceBtn[i].GetComponentInChildren<Text>().text = "" + Random.Range(0, 41);
                }
            }
        }
    }
}
