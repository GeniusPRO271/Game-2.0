using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate (){
            OnClick(param);
        });
    }
}
public class IteamChoose : MonoBehaviour
{
    public UpdateStats update;
    public WeightedRandomList<Scriptalbe_Items> IteamToChoosed;
    private List<Scriptalbe_Items> ListOfItems = new List<Scriptalbe_Items>();
    public PauseToChoose choose;

    public void CheckForClone()
    {
        Debug.Log("EnterLoop");
        for (int i = 0; i < 2; i++)
        {
            if (ListOfItems[i] != ListOfItems[i + 1])
            {
                if (ListOfItems[i] == ListOfItems[3 - 1])
                {
                    Debug.Log("Change 2 ");
                    ListOfItems[i] = IteamToChoosed.GetRandom();
                    CheckForClone();
                }
            }
            else {
                Debug.Log("Change 1 ");
                ListOfItems[i] = IteamToChoosed.GetRandom();
                CheckForClone();
                    }
        }
    }
    public void GetIteamRandom()
    {
        for (int i = 0; i < 3; i++)
        {
            Scriptalbe_Items random = IteamToChoosed.GetRandom();
            ListOfItems.Add(random);
            Debug.Log(ListOfItems[i]);
        }
        CheckForClone();
    }
    public void GetUpgrade()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;
        GetIteamRandom();
        for (int i = 0; i < 3; i++)
        {
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(2).GetComponent<TMP_Text>().text = ListOfItems[i].description;
            g.transform.GetChild(0).GetComponent<Image>().sprite = ListOfItems[i].IteamLogo;

            g.GetComponent<Button>().AddEventListener(i, IteamClicked);
        }
        Destroy(buttonTemplate);
    }

    void IteamClicked(int iteamindex)
    {
        Debug.Log(iteamindex);
        Debug.Log(ListOfItems[iteamindex]);
        update.UpdatePlayerStats(ListOfItems[iteamindex]);
        for (int i = 0; i < 2; i++) Destroy(transform.GetChild(i).gameObject);
            choose.IteamChoosed_Unpause();
    }
}
