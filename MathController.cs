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
    private float localofAnswer;//เก็บตำแหน่งคำตอบที่ถูก
    public int score;
    public GameObject[] choiceBtn;//จำนวน choice 4 ตัว
    public string tagBtn;//บอกว่า choice ไหนถูกไหนผิด
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
    //สร้าง function ในการสุ่มตัวเลขและนำตัวเลขมาบวกกัน
    public void AdditionMethod()
    {
        a = Random.Range(0, 21);//min,max (0-21)
        b = Random.Range(0, 21);
        valueA.text = "" + a;
        valueB.text = "" + b;
        answer = a + b;
        Debug.Log(answer);

        //สุ่มตำแหน่งที่จะใส่คำตอบที่ถูก
        localofAnswer = Random.Range(0,choiceBtn.Length);//ตำแหน่งของปุ่มที่ถูก

        //ลูป choice
        for (int i=0;i<choiceBtn.Length;i++)
        {
            //เพื่อเปลี่ยนตัวเลขด้านใน
            //ตำแหน่งตรงกับ localofAnswer
            if (i==localofAnswer)
            {
                //ใส่คำตอบที่ถูกลงใน Text ของปุ่ม
                choiceBtn[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {
                //ใส่คำตอบที่ผิดลงในปุ่ม
                choiceBtn[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 41);
                while (choiceBtn[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    choiceBtn[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 41);
                }
            }
        }
    }
}
