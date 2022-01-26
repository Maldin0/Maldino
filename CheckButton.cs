using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    private AudioSource au;
    public AudioClip[] sound;
    public Image background;
    // Start is called before the first frame update
    void Start()
    {
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame

    public void checkTagButton()
    {
        //ตอบถูกได้คะแนน
        if (gameObject.CompareTag(MathController.instance.tagBtn))
        {
            MathController.instance.score++;
            MathController.instance.AdditionMethod();//เปลี่ยนโจทย์
            Debug.Log(MathController.instance.score);
            TimeBarScript.instance.currentTime = 1;
            au.PlayOneShot(sound[0]);
        }
        else
        {
            StartCoroutine(ChangeColor());
            MathController.instance.score--;
            MathController.instance.AdditionMethod();//เปลี่ยนโจทย์
            Debug.Log(MathController.instance.score);
            TimeBarScript.instance.currentTime = 1;
            au.PlayOneShot(sound[1]);
        }
        IEnumerator ChangeColor()
        {
            //พื้นหลังสีแดง RGBA
            background.color = new Color32(221, 127, 127, 255);
            yield return new WaitForSeconds(0.05f);
            background.color = new Color32(154, 154, 154, 255);
        }
    }
}
