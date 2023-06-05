using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField] private List<MenuSwitcher> _menus;

    public void OpenMenu(string menuName)
    {
        foreach (MenuSwitcher menu in _menus)
        {
            if (menu.menuName == menuName)
            {
                menu.Open();
            }
            else
            {
                menu.Close();
            }
        }
    }

    void Awake()
    {
        instance = this;
    }

}
