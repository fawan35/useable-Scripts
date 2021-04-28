using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerprefz : MonoBehaviour
{
    /// <summary>
    /// Strings for Guns Details
    /// </summary>
    public const string STR_MAGZINESIZE = "STR_MagzineSize";
    public const string STR_BULLTEDAMAGE = "STR_BlteDamage";
    public const string STR_RECOIL = "STR_RECOIL";
    public const string STR_RELOADING = "STR_RELOADING";
    public const string STR_CURRENTLEVEL = "STR_CURRENTLEVEL";
    public const string STR_CHPNO = "STR_CHPNO";
    public const string STR_Grenade = "STR_Grenade";
    public const string STR_Healthkit = "STR_Healthkit";
    public const string STR_WeaponType = "STR_WeaponType";
    public const string STR_CurrentGun = "STR_CRNTGUN";
    public const string STR_GUN = "STR_GUN";
    public const string STR_CurrentWeaponType = "STR_CurrentWeaponType";
    public const string STR_GunUpdateNo = "STR_GunUpdateNo";
    public const string STR_Sensitivity = "STR_Sensitivity";
    public const string STR_AutoSHoot = "STR_AutoSHoot";
    public const string STR_WatchUnlockMode = "STR_WatchUnlockMode";


    /// <summary>
    /// Strings for TAG Details
    /// </summary>
    public const string TAG_HEAD = "head";
    public const string TAG_PLAYER = "Player";
    public const string TAG_ENEMY = "enemy";

    /// <summary>
    /// strings for Scenes Detail
    /// </summary>
    public const string SCN_Gameplay1 = "Gameplay1";
    public const string SCN_Gameplay2 = "Gameplay2";
    public const string SCN_Gameplay3 = "Gameplay3";
    public const string SCN_Gameplay4 = "Gameplay4";
    public const string SCN_Gameplay5 = "Gameplay5";
    public const string SCN_MainMenu = "MainMenu";
    public static bool NextLevel = false;
    public static bool GamePause = false;
    //public static bool GameCutscene = false;
    public static bool CheckHideAllUI = false;

    public static bool OpenGrenadePanel = false;
    /// <summary>
    /// String for Level Details
    /// </summary>
    public const string LVL_Current = "LVL_Current";
    public const string LVL_Unlocked = "LVL_Unlocked";

    /// <summary>
    /// Strings for Mode Details
    /// </summary>
    public const string MODE_Current = "MODE_Current";
    public const string MODE_Unlocked = "MODE_Unlocked";

    /// <summary>
    /// Strings For Cash And Rewards
    /// </summary>
    public const string CASH_TOTAL = "CASH_TOTAL";
    public const string COIN_TOTAL = "COIN_TOTAL";
    public const string CASH_LEVELREWARD = "CASH_LEVELREWARD";

    public static void SetCurrentWeaponCategory(int weapontype)
    {
         PlayerPrefs.SetInt(STR_CurrentWeaponType, weapontype);

    }

    public static int getCurrentWeaponCategory()
    {
        return PlayerPrefs.GetInt(STR_CurrentWeaponType, 0);
    }

    public static void setGunPurchased(int GunNo)
    {
        PlayerPrefs.SetInt(STR_GUN+getCurrentWeaponCategory() + GunNo, 1);
        setCurrentGun(GunNo);
        //PlayerPrefs.SetInt;

    }
    //public static void GiftFirstWeaponsEachCategory()
    //{
    //    for (int i = 0; i < 5; i++)
    //    {

    //        PlayerPrefs.SetInt(STR_GUN + i + 0, 1);
    //    }
    //}
    public static int getGunPurchased(int GunNo)
    {
        if(GunNo == 0)
        {
            return  1;
        }
        else
        return PlayerPrefs.GetInt(STR_GUN + getCurrentWeaponCategory() + GunNo, 0);
    }
    public static void setCurrentGun(int GunNo)
    {
        PlayerPrefs.SetInt(STR_CurrentGun + getCurrentWeaponCategory(), GunNo);
        //PlayerPrefs.SetInt;

    }
    public static int getCurrentGun()
    {
        return PlayerPrefs.GetInt(STR_CurrentGun + getCurrentWeaponCategory(), 0);
    }

    public static void setCurrentLevel(int i)
    {
        PlayerPrefs.SetInt(LVL_Current, i);
    }

    public static int getCurrentLevel( )
    {
        return PlayerPrefs.GetInt(LVL_Current, 0);
    }

    public static void setGunUpdate(int CurrentUpdate,int guntype,int part)
    {
        print(STR_GunUpdateNo + guntype + part + ":NO:" + CurrentUpdate);

        PlayerPrefs.SetInt(STR_GunUpdateNo + guntype + part, CurrentUpdate);
    }

    public static int getGunUpdate(int guntype,int part)
    {
        //print(STR_GunUpdateNo + guntype + part);
        return PlayerPrefs.GetInt(STR_GunUpdateNo + guntype + part, 0);
        
    }
    public static void setUnlockNextLevel()
    {
        if (getUnlockedLevel(getCurrentMode()) <= getCurrentLevel())
        {
            PlayerPrefs.SetInt(LVL_Unlocked + getCurrentMode(), getCurrentLevel() + 1);
            print("Unlocked Level :" + getUnlockedLevel(getCurrentMode()));
        }
        else
        {
            print("Already Unlocked:" + getUnlockedLevel(getCurrentMode()) + " Current LVL:"+ getCurrentLevel());

        }
    }
    public static int getUnlockedLevel(int _CurrentMode)
    {
        return PlayerPrefs.GetInt(LVL_Unlocked+_CurrentMode, 1);
    }

    public static void SetWatchUnlockMode(int no)
    {
        PlayerPrefs.SetInt(STR_WatchUnlockMode + no, 1);
    }
    public static int GetWatchUnlockMode(int no)
    {
        return PlayerPrefs.GetInt(STR_WatchUnlockMode + no, 0);
    }
    public static int getTotalUnlockedLevel(int _CurrentMode, int totalLevels)
    {
        int total = 0;
        for (int i = 0; i < totalLevels; i++)
        {
            if (getUnlockedLevel(_CurrentMode) < i)
                ;
            else
                total++;
        }

        return  total;
    }
    public static void setUnlockNextMode(int selectedmode)
    {
        if (getUnlockedMode(selectedmode) != 1)
        {
            PlayerPrefs.SetInt(MODE_Unlocked + getCurrentMode(), 1);
            print("Unlocked Mode :" + getUnlockedMode(selectedmode));
        }
        else
        {
            //print("Already Unlocked:" + getUnlockedLevel(getCurrentMode()) + " Mode:"+ getCurrentLevel());
            print("Already Unlocked Mode :" + getUnlockedMode(selectedmode));

        }
    }
    public static int getUnlockedMode(int _CurrentMode)
    {
        if (_CurrentMode == 0)
        {
            return 1;
        }
        else
        return PlayerPrefs.GetInt(MODE_Unlocked + _CurrentMode, 0);
    }
    public static void setCurrentMode(int i)
    {
        PlayerPrefs.SetInt(MODE_Current, i);
    }

    public static int getCurrentMode()
    {
        return PlayerPrefs.GetInt(MODE_Current, 0);
    }

    // ***************************** Staring Cash methods **************************
    public static void AddinTotalCash(int Cash)
    {
        PlayerPrefs.SetInt(CASH_TOTAL, getTotalCash + Cash);

    }
    public static void RemoveinTotalCash(int Cash)
    {
        PlayerPrefs.SetInt(CASH_TOTAL, getTotalCash - Cash);

    }
    public static int getTotalCash
    {
        get
        {
          return  PlayerPrefs.GetInt(CASH_TOTAL, 0);

        }
    }

    //  ******************* Starting Coin Methods *****************
     public static void AddinTotalCoin(int Coin)
    {
        PlayerPrefs.SetInt(COIN_TOTAL, getTotalCoin + Coin);

    }
public static void RemoveinTotalCoin(int Coin)
{
    PlayerPrefs.SetInt(COIN_TOTAL, getTotalCoin - Coin);

}
public static int getTotalCoin
{
    get
    {
        return PlayerPrefs.GetInt(COIN_TOTAL, 0);

    }
}

public static int CurrentLevelReward
    {
        get
        {
            return PlayerPrefs.GetInt(CASH_LEVELREWARD, 100);

        }
        set
        {
            PlayerPrefs.SetInt(CASH_LEVELREWARD, value);
        }
    }
  
    public static void AddinHealthkit(int value)
    {
        PlayerPrefs.SetInt(STR_Healthkit, GetHealthkit + value);
    }

    public static void RemovedinHealthkit()
    {

        PlayerPrefs.SetInt(STR_Healthkit, GetHealthkit - 1);

    }
    public static int GetHealthkit
    {
        get
        {
            return PlayerPrefs.GetInt(STR_Healthkit, 2);
        }
    }


    public static void AddinGrenade(int value)
    {
        PlayerPrefs.SetInt(STR_Grenade, GetGrenade + value);
    }

    public static void setRemovedinGrenade()
    {

        PlayerPrefs.SetInt(STR_Grenade, GetGrenade - 1);

    }
    public static int  GetGrenade
    {
        get
        {
            return PlayerPrefs.GetInt(STR_Grenade, 5);
        }
    }


    public static void SetSensitivty(float sensitivity)
    {
        PlayerPrefs.SetFloat(STR_Sensitivity, sensitivity*3);
    }
    public static float GetSensitivity()
    {
        return PlayerPrefs.GetFloat(STR_Sensitivity, 1.5f);
    }
    public static void SetAutoShoot(int autoshot)
    {
        PlayerPrefs.SetFloat(STR_AutoSHoot,autoshot);
    }
    public static bool GetGetAutoShoot()
    {
        if (PlayerPrefs.GetInt(STR_AutoSHoot, 1) == 1)
            return true;
        else
            return false;
    }
}
