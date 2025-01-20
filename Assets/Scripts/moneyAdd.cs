using UnityEngine;

public class moneyAdd : MonoBehaviour
{
    public void AddMoney(){
           SaveManager.instance.money += 100;
           SaveManager.instance.Save();
       }
       
    public void SubMoney(){
        SaveManager.instance.money -= 100;
        SaveManager.instance.Save();
    }
}

