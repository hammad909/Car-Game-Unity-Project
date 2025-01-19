using UnityEngine;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{
    [Header("Navigation Button")]
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;
    private int currentCar;
    [Header("Play/Buy Button")]
    [SerializeField] private Button play;
    [SerializeField] private Button buy;
    [SerializeField] private Text txt;
    
     [SerializeField]public int[] carPrices;
    private void Start()
    {
        currentCar = SaveManager.instance.currentCar;
        SelectCar(currentCar);
    }

    private void SelectCar(int _index)
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(i == _index);
            UpdateUI();
    }

    public void UpdateUI(){
        
            if(SaveManager.instance.carsUnlocked[currentCar]){
                play.gameObject.SetActive(true);
                buy.gameObject.SetActive(false);
            }else{
                play.gameObject.SetActive(false);
                buy.gameObject.SetActive(true);
                txt.text = carPrices[currentCar] + "$";
            }
    }
    
    public void Update(){
        if(buy.gameObject.activeInHierarchy){
            buy.interactable = (SaveManager.instance.money >= carPrices[currentCar]);
        }
    }
    
    public void ChangeCar(int _change)
    {
        currentCar += _change;

        if (currentCar > transform.childCount - 1)
            currentCar = 0;
        else if (currentCar < 0)
            currentCar = transform.childCount - 1;

        SaveManager.instance.currentCar = currentCar;
        SaveManager.instance.Save();
        SelectCar(currentCar);
    }
    
    public void BuyCar(){
        SaveManager.instance.money -= carPrices[currentCar]; 
        SaveManager.instance.carsUnlocked[currentCar] = true;
        SaveManager.instance.Save();
        UpdateUI();
    }
}