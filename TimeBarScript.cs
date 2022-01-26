using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBarScript : MonoBehaviour
{
    public Transform fillbar;
    public float currentTime;//Tell the time
    public float delay=0.5f;
    public static TimeBarScript instance;

    void Start()
    {

        currentTime = 1;
    }
    private void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= delay * Time.deltaTime;//Reduce currentTime
        fillbar.GetComponent<Image>().fillAmount = currentTime;
        if (currentTime < 0.1f)
        {
            Application.LoadLevel("Home");
        }
    }
}
