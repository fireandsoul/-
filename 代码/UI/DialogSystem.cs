using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("===UI组件 ===")]
    public Text textLabel;
    public Image faceImage;

    [Header("===文本文件 ===")]
    public TextAsset textFile;
    public int index;//行数
    public float textSpeed = 0.1f;
    bool textFinshed ;

    [Header("===头像 ===")]
    public Sprite face01;
    public Sprite face02;

    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        GetTxtFormFile(textFile);
     
    }
    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinshed = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {    if(Input.GetKeyDown(KeyCode.R) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && textFinshed ==true)
        {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTxtFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        
        var lineData =  file.text.Split('\n');
        foreach(var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinshed = false;
        textLabel.text = "";



        switch (textList[index])
        {
            case "A":
                print("转换a头像");
                faceImage.sprite = face01;
                index++;
                break;
            case "B":
                print("转换b头像");
                faceImage.sprite = face02;
                index++;
                break;

        }



        for (int i = 0;i <textList[index].Length;i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinshed = true;
        index++;
    }
}
