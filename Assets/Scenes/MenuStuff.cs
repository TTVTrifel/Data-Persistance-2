using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Analytics.IAnalytic;

public class MenuStuff : MonoBehaviour
{

    public TMP_InputField field;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Start()
    {
        field.onValueChanged.AddListener(ChangeName);
        Button myButton = GetComponent<Button>();
        field.text =  SaveThing.Instance.GetName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ChangeName(string name)
    {
        SaveThing.Instance.SaveName(name);
    }
}
