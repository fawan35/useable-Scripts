using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [Header("On Enable Call Methods adn Object on/off")]
    public GameObject[] OnEnablesOn;
    public GameObject[] OnEnablesOff;
    public UnityEngine.Events.UnityEvent OnEnablecall;

    [Header("On Disable Call Methods and Object on/off")]
    public GameObject[] OnDisablesOn;
    public GameObject[] OnDisablesOff;
    public UnityEngine.Events.UnityEvent OnDisablecall;


    #region Mono Menthods

    private void OnEnable()
    {
        for (int i = 0; i < OnEnablesOn.Length; i++)
        {
            if (OnEnablesOn[i])
            {
                OnEnablesOn[i].SetActive(true);
            }
        }

        for (int i = 0; i < OnEnablesOff.Length; i++)
        {
            if (OnEnablesOff[i])
            {
                OnEnablesOff[i].SetActive(false);
            }
        }

        OnEnablecall.Invoke();
    }

    private void OnDisable()
    {
        for (int i = 0; i < OnDisablesOn.Length; i++)
        {
            if (OnDisablesOn[i])
            {
                OnDisablesOn[i].SetActive(true);
            }
        }

        for (int i = 0; i < OnDisablesOff.Length; i++)
        {
            if (OnDisablesOff[i])
            {
                OnDisablesOff[i].SetActive(false);
            }
        }

        OnDisablecall.Invoke();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
}
