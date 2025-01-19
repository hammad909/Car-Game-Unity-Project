using UnityEngine;
using UnityEngine.UI;

public class moneyCalculator : MonoBehaviour
{
   private Text txt;
   
   private void Awake(){
       txt = GetComponent<Text>();
   }
   private void Update(){
       txt.text = SaveManager.instance.money + "s";
   }
}
