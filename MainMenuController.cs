using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Screens
{
    WeaponSelection,
    ModeSelection,
    LevelSelection,
    iapShopAll,
    iapShopGold,
    iapShopCash,
    XP_screen,
    ExitScreen,
    SettingScreen,
        MainMenu

}
public class MainMenuController : MonoBehaviour
{
    #region Public Variables
    [Tooltip("WeaponSelection, ModeSelection, LevelSelection, iapShopAll,iapShopGold, iapShopCash, XP_screen, ExitScreen, ")]
    /// <summary>
    /// Screen{0} -->  WeaponSelection,
    /// Screen{1} -->ModeSelection,
    /// Screen{2} -->LevelSelection,
    /// Screen{3} -->iapShopAll,
    /// Screen{4} -->iapShopGold,
    /// Screen{5} -->iapShopCash,
    /// Screen{6} -->XP_screen,
    /// Screen{7} -->ExitScreen,
    /// Screen{8} -->SettingScreen,
    /// Screen{9} -->MainMenuScreen,
    /// </summary>
    public GameObject[] ScreenPanels;

    public string MoreGamesURL;
    public Text[] txt_Cash;
    public Text[] txt_Gold;


    #endregion


    #region Private Variables
    public Stack<GameObject> OpenPanels = new Stack<GameObject>();
    #endregion

    #region Buttons
    public Button btn_Play;
    public Button btn_MoreGames;
    public Button btn_Rateus;
    public Button btn_PrivacyPolicy;
    public Button btn_Setting;
    public Button btn_XP;
    public Button btn_shop;
    public Button btn_shopTopbar;
    public Button btn_Exit;
    public Button btn_iapCash;
    public Button btn_iapGold;
    public Button btn_back;

    #endregion



    #region Mono Methods

    // Start is called before the first frame update
    void Start()
    {
        starting_Initializations();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Custom Methods

    void starting_Initializations()
    {
        OffAllScreens();

        GetScreen(Screens.MainMenu);

        btn_Play.onClick.AddListener(() =>
        {
            GetScreen(Screens.WeaponSelection);

        });

        btn_MoreGames.onClick.AddListener(() =>
        {

            Application.OpenURL(MoreGamesURL);

        });

        btn_Rateus.onClick.AddListener(() =>
        {

            

        });

        btn_PrivacyPolicy.onClick.AddListener(() =>
        {


        });
        btn_Setting.onClick.AddListener(() =>
        {
            GetScreen(Screens.SettingScreen);

        });
        btn_XP.onClick.AddListener(() =>
        {

            GetScreen(Screens.XP_screen);

        });
        btn_shop.onClick.AddListener(() =>
        {

            GetScreen(Screens.iapShopAll);

        });
        btn_shopTopbar.onClick.AddListener(() =>
        {

            GetScreen(Screens.iapShopAll);

        });
        btn_Exit.onClick.AddListener(() =>
        {

            GetScreen(Screens.ExitScreen);

        });
        btn_iapCash.onClick.AddListener(() =>
        {
            GetScreen(Screens.iapShopCash);


        });
        btn_iapGold.onClick.AddListener(() =>
        {
            GetScreen(Screens.iapShopGold);


        });
        btn_back.onClick.AddListener(() =>
        {

            method_backBTN();
        });



    }

    void method_backBTN()
    {
        if (OpenPanels.Count <= 1)
        {
            //do nothing just 
            print("Already Full Back");
            return;
        }
        OpenPanels.Pop().SetActive(false);

        if(OpenPanels.Count == 1){
            OpenPanels.Peek().SetActive(true);

        }

    }


    public GameObject GetScreen(Screens _Screen)
    {
        GameObject CurrentScreen;
        if (OpenPanels.Count > 0)
            OpenPanels.Peek().SetActive(false);
        switch (_Screen)
        {
            default:
            case Screens.WeaponSelection:
                CurrentScreen = ScreenPanels[0];

                break;

            case Screens.ModeSelection:
                CurrentScreen = ScreenPanels[1];
                break;

            case Screens.LevelSelection:
                CurrentScreen = ScreenPanels[2];
                break;

            case Screens.iapShopAll:
                CurrentScreen = ScreenPanels[3];
                break;
            case Screens.iapShopGold:
                CurrentScreen = ScreenPanels[4];
                break;
            case Screens.iapShopCash:
                CurrentScreen = ScreenPanels[5];
                break;
            case Screens.XP_screen:
                CurrentScreen = ScreenPanels[6];
                break;
            case Screens.ExitScreen:
                CurrentScreen = ScreenPanels[7];
                break;
            case Screens.SettingScreen:
                CurrentScreen = ScreenPanels[8];
                break;
            case Screens.MainMenu:
                CurrentScreen = ScreenPanels[9];
                break;
        }
        OpenPanels.Push(CurrentScreen);
        CurrentScreen.SetActive(true);


        return CurrentScreen;
    }


    void OffAllScreens()
    {
        for (int i = 0; i < ScreenPanels.Length; i++)
        {
            ScreenPanels[i].SetActive(false);
        }
    }
    #endregion

}
