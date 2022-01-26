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
    private float localofAnswer;//�纵��˹觤ӵͺ���١
    public int score;
    public GameObject[] choiceBtn;//�ӹǹ choice 4 ���
    public string tagBtn;//�͡��� choice �˹�١�˹�Դ
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
    //���ҧ function 㹡����������Ţ��йӵ���Ţ�Һǡ�ѹ
    public void AdditionMethod()
    {
        a = Random.Range(0, 21);//min,max (0-21)
        b = Random.Range(0, 21);
        valueA.text = "" + a;
        valueB.text = "" + b;
        answer = a + b;
        Debug.Log(answer);

        //�������˹觷������ӵͺ���١
        localofAnswer = Random.Range(0,choiceBtn.Length);//���˹觢ͧ�������١

        //�ٻ choice
        for (int i=0;i<choiceBtn.Length;i++)
        {
            //��������¹����Ţ��ҹ�
            //���˹觵ç�Ѻ localofAnswer
            if (i==localofAnswer)
            {
                //���ӵͺ���١ŧ� Text �ͧ����
                choiceBtn[i].GetComponentInChildren<Text>().text = "" + answer;
            }
            else
            {
                //���ӵͺ���Դŧ㹻���
                choiceBtn[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 41);
                while (choiceBtn[i].GetComponentInChildren<Text>().text == "" + answer)
                {
                    choiceBtn[i].GetComponentInChildren<Text>().text = "" + Random.Range(1, 41);
                }
            }
        }
    }
}
