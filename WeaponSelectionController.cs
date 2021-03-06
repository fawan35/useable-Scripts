using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public struct SpecificationsValue
{
    public string Name;
    [Range(0,1)]
    public float power;
    [Range(0,1)]
    public float maxzoom;
    [Range(0,1)]
    public float stability;
    [Range(0,1)]
    public float reload;
    [Range(0,1)]
    public float LifeDetection;
    [Range(0,1)]
    public float ClipSize;

    public Sprite item;
    public GameObject Model;
    public int Currency;
    public int Cash;
    public int Coin;

}
[System.Serializable]

public struct WeaponCategory
{
    public Weapontype Type;
    public Button BTN_TypeSelect;
    public Color ClickedColor;

    public SpecificationsValue[] Weapon;

}
public enum Weapontype
{
    Gun,
    Bow, 
    Archer,
    Axe,
}
[System.Serializable]
public struct SpecificationRef
{
    public Image fillBar;


}
[System.Serializable]
public struct WeaponBTNS
{
    public Button Item;
}

public class WeaponSelectionController : MonoBehaviour
{
    #region Public Variables
    [Header("********* Weapon Buttons ****************")]
    public WeaponBTNS[] BTN_Weapons;
    [Header("************ Weapon Category And Specs ********")]
    public WeaponCategory[] WeaponSpecs;
    [Header("************ UI Specs ********")]
    public SpecificationRef bar_Power;
    public SpecificationRef bar_MaxZoom;
    public SpecificationRef bar_Stability;
    public SpecificationRef bar_Reload;
    public SpecificationRef bar_LifeDetection;
    public SpecificationRef ClipSize;

    [Header("************ Equip/Buy Buttons ********")]
    public Button btn_CoinBuy;
    public Button btn_CashBuy;
    public Button btn_CurrencyBuy;
    public Button btn_Equip;
    public Button btn_Hunt;

    public UnityEngine.Events.UnityEvent OnIAPitemClick;
    #endregion
    #region Private Variables

    [SerializeField]
    int currentitem;
    [SerializeField]
    int currentWeaponType;
    WeaponCategory CurrentWeapon;
    #endregion

    #region Mono Methods
    // Start is called before the first frame update
    void Start()
    {
        //playerprefz.GiftFirstWeaponsEachCategory();
        Initializations();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion


    #region Custom Method 

    void Initializations()
    {
        for (int i = 0; i < WeaponSpecs.Length; i++)
        {
            int a = i;
            WeaponSpecs[i].BTN_TypeSelect.onClick.AddListener(() =>
            {
                OnWeaponTypeClick((Weapontype)a);
            });
        }

        for (int i = 0; i < BTN_Weapons.Length; i++)
        {
            int a = i;
            BTN_Weapons[i].Item.onClick.AddListener(()=> {

                OnWeaponClick(a);

            });
        }

        btn_CashBuy.onClick.AddListener(()=> {
            PurchaseGunCash();
        });
        btn_CoinBuy.onClick.AddListener(() => {
            PurchaseGunCoin();
        });
        btn_CurrencyBuy.onClick.AddListener(() => {
            PurchaseGunIAP();
        });
        btn_Equip.onClick.AddListener(() => {
            EquipOnclick();
        });
        btn_Hunt.onClick.AddListener(() => {

            HuntOnclick();
        });

        currentWeaponType = playerprefz.getCurrentWeaponCategory();
        currentitem = playerprefz.getCurrentGun();
        OnWeaponTypeClick((Weapontype)currentWeaponType);
        //CurrentWeapon = WeaponSpecs[currentWeaponType];
        WeaponItemsUpdate();
       
    }

    public void onPanelOpen()
    {
        currentWeaponType = playerprefz.getCurrentWeaponCategory();
        currentitem = playerprefz.getCurrentGun();
        //print("CurrntItem :" + currentitem);
        WeaponItemsUpdate();
    }
    void WeaponItemsUpdate()
    {
        
        for (int i = 0; i < BTN_Weapons.Length; i++)
        {
            //BTN_Weapons[i].Item.transform.GetChild(3).gameObject.SetActive(false);

            if (playerprefz.getGunPurchased(i) == 1)
            {

                //btn_CashBuy.gameObject.SetActive(false);
                //btn_CoinBuy.gameObject.SetActive(false);
                //btn_CurrencyBuy.gameObject.SetActive(false);
                //btn_Equip.gameObject.SetActive(true);
                //btn_Hunt.gameObject.SetActive(true);
                
                BTN_Weapons[i].Item.transform.GetChild(1).gameObject.SetActive(false);
                
                
                if(playerprefz.getCurrentGun() == i)
                {
                    //btn_Equip.interactable = false;
                    BTN_Weapons[i].Item.transform.GetChild(3).gameObject.SetActive(true);
                }

            }
            else
            {
                BTN_Weapons[i].Item.transform.GetChild(1).gameObject.SetActive(true);
                BTN_Weapons[i].Item.transform.GetChild(3).gameObject.SetActive(false);
                btn_Equip.gameObject.SetActive(false);
                btn_Hunt.gameObject.SetActive(false);
                btn_CashBuy.gameObject.SetActive(true);
                btn_CoinBuy.gameObject.SetActive(true);
                btn_CurrencyBuy.gameObject.SetActive(true);

            }
            BTN_Weapons[i].Item.transform.GetChild(0).GetComponent<Image>().sprite = CurrentWeapon.Weapon[i].item;

        }


        //BTN_Weapons[i].Item.transform.GetChild(2).gameObject.SetActive(true);
        itemSpecsUpdate();

    }
    void ResetAllSelection()
    {
        for (int i = 0; i < BTN_Weapons.Length; i++)
        {
            BTN_Weapons[i].Item.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
    void itemSpecsUpdate()
    {
        ResetAllSelection();

        if (playerprefz.getGunPurchased(currentitem) == 1)
        {
            //playerprefz.setCurrentGun(currentitem);
            btn_CashBuy.gameObject.SetActive(false);
            btn_CoinBuy.gameObject.SetActive(false);
            btn_CurrencyBuy.gameObject.SetActive(false);
            btn_Equip.gameObject.SetActive(true);
            btn_Hunt.gameObject.SetActive(true);
            if (playerprefz.getCurrentGun() == currentitem)
            {
                btn_Equip.interactable = false;
            }
            else
            {
                btn_Equip.interactable = true;

            }
        }
        else
        {
            BTN_Weapons[currentitem].Item.transform.GetChild(1).gameObject.SetActive(true);
            BTN_Weapons[currentitem].Item.transform.GetChild(3).gameObject.SetActive(false);
            btn_Equip.gameObject.SetActive(false);
            btn_Hunt.gameObject.SetActive(false);
            btn_CashBuy.gameObject.SetActive(true);
            btn_CoinBuy.gameObject.SetActive(true);
            btn_CurrencyBuy.gameObject.SetActive(true);

        }

        bar_Power.fillBar.fillAmount = CurrentWeapon.Weapon[currentitem].power;
        bar_MaxZoom.fillBar.fillAmount = CurrentWeapon.Weapon[currentitem].maxzoom;
        bar_Stability.fillBar.fillAmount = CurrentWeapon.Weapon[currentitem].stability;
        bar_Reload.fillBar.fillAmount = CurrentWeapon.Weapon[currentitem].reload;
        bar_LifeDetection.fillBar.fillAmount = CurrentWeapon.Weapon[currentitem].LifeDetection;
        ClipSize.fillBar.fillAmount = CurrentWeapon.Weapon[currentitem].ClipSize;
        offAllModels();
        CurrentWeapon.Weapon[currentitem].Model.SetActive(true);
        BTN_Weapons[playerprefz.getCurrentGun()].Item.transform.GetChild(3).gameObject.SetActive(true);

        btn_CashBuy.transform.GetChild(0).GetComponent<Text>().text = CurrentWeapon.Weapon[currentitem].Cash.ToString();
        btn_CoinBuy.transform.GetChild(0).GetComponent<Text>().text = CurrentWeapon.Weapon[currentitem].Coin.ToString();
        btn_CurrencyBuy.transform.GetChild(0).GetComponent<Text>().text = CurrentWeapon.Weapon[currentitem].Currency.ToString();

    }
    public void offAllModels()
    {
        for (int i = 0; i < WeaponSpecs.Length; i++)
        {
            for (int j = 0; j < WeaponSpecs[i].Weapon.Length; j++)
            {
                WeaponSpecs[i].Weapon[j].Model.SetActive(false);
            }
        }
    }
    void OnWeaponClick(int no)
    {
        currentitem = no;
        itemSpecsUpdate();
    }
    void OnWeaponTypeClick(Weapontype weapontype)
    {

        playerprefz.SetCurrentWeaponCategory((int)weapontype);
        CurrentWeapon = WeaponSpecs[(int)weapontype];
        currentitem = playerprefz.getCurrentGun();
        for (int i = 0; i < WeaponSpecs.Length; i++)
        {
            WeaponSpecs[i].BTN_TypeSelect.GetComponent<Image>().color = Color.white;
        }
        CurrentWeapon.BTN_TypeSelect.GetComponent<Image>().color = CurrentWeapon.ClickedColor;

        WeaponItemsUpdate();
    }

    void PurchaseGunCash()
    {
        if(playerprefz.getTotalCash >= CurrentWeapon.Weapon[currentitem].Cash)
        {
            playerprefz.RemoveinTotalCash(CurrentWeapon.Weapon[currentitem].Cash);
            playerprefz.setGunPurchased(currentitem);
            WeaponItemsUpdate();
        GetComponent<MainMenuController>().UpdateCurrency();
        }
        else
        {
            print("not Enough Cash");
        }
    }

    void PurchaseGunCoin()
    {
        if (playerprefz.getTotalCoin >= CurrentWeapon.Weapon[currentitem].Coin)
        {
            playerprefz.RemoveinTotalCoin(CurrentWeapon.Weapon[currentitem].Coin);
            playerprefz.setGunPurchased(currentitem);
            WeaponItemsUpdate();
            GetComponent<MainMenuController>().UpdateCurrency();
        }
        else
        {
            print("not Enough Coin");
        }
    }
    void PurchaseGunIAP()
    {
        GetComponent<MainMenuController>().UpdateCurrency();
        OnIAPitemClick.Invoke();
    }
    void HuntOnclick()
    {
        GetComponent<MainMenuController>().GetScreen(Screens.ModeSelection);

    }
    void EquipOnclick()
    {
        playerprefz.setCurrentGun(currentitem);
        itemSpecsUpdate();
    }


    #endregion
}
