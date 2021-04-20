using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Main_menu : MonoBehaviour
{
    private GameObject _world;
    [SerializeField] private Canvas _canvas;
    private Dictionary<string, GameObject> _uiElements = new Dictionary<string, GameObject>();
    private void Awake()
    {
        if (_canvas != null)
        {
            _canvas.gameObject.SetActive(true);
        }
        else
        {
            throw new InvalidOperationException("Canvas is not set!!");
        }
    }

    private void Start()
    {
        _world = GameObject.FindGameObjectWithTag("World");
        if (_world != null)
        {
            _world.SetActive(false);
        }
        var canvasChilds = _canvas.GetComponentsInChildren<Transform>();
        for (int i = 1; i < canvasChilds.Length; i++)
        {
            if (canvasChilds[i].childCount > 0)
            {
                _uiElements.Add(canvasChilds[i].name, canvasChilds[i].gameObject);
            }
        }

        if (_uiElements.ContainsKey("Play"))
        {
            _uiElements["Play"].GetComponent<Button>().onClick.AddListener(EnableWorld);
        }
        if (_uiElements.ContainsKey("Pause"))
        {
            _uiElements["Pause"].SetActive(false);
            _uiElements["Pause"].GetComponent<Button>().onClick.AddListener(SettingStop);
        }
        if (_uiElements.ContainsKey("Settings"))
        {
            _uiElements["Settings"].GetComponent<Button>().onClick.AddListener(Settings);  
        }
        if (_uiElements.ContainsKey("Exit"))
        {
            _uiElements["Exit"].GetComponent<Button>().onClick.AddListener(Exit);
        }
        if (_uiElements.ContainsKey("SettMenu"))
        {
            _uiElements["SettMenu"].SetActive(false);
            _uiElements.ContainsKey("Sound");
            _uiElements.ContainsKey("Music");
        
            if (_uiElements.ContainsKey("Back")) 
            {
                _uiElements["Back"].GetComponent<Button>().onClick.AddListener(Back);
            }
            if (_uiElements.ContainsKey("BackToPlay"))
            {
                _uiElements["BackToPlay"].SetActive(false);
                _uiElements["BackToPlay"].GetComponent<Button>().onClick.AddListener(BackToPlay);
            }
            if (_uiElements.ContainsKey("BackToMenu"))
            {
                _uiElements["BackToMenu"].SetActive(false);
                _uiElements["BackToMenu"].GetComponent<Button>().onClick.AddListener(BackToMenu);
            }   
        }
        
    }

   
        
    
    private void Settings()
    {
        _uiElements["Settings"].SetActive(true);
        if (_uiElements.ContainsKey("SettMenu"))
        {
            foreach(var item in _uiElements)
            {
                item.Value.SetActive(false); ;
            }
            _uiElements["SettMenu"].SetActive(true);
            _uiElements["Sound"].SetActive(true);
            _uiElements["Music"].SetActive(true);
            _uiElements["Back"].SetActive(true);
        }
    }

    private void Back()
    {
        _world.SetActive(false);
        foreach (var item in _uiElements)
        {
            item.Value.SetActive(!item.Value.activeSelf);
            
        }
    }

    private void BackToPlay()
    {
        _world.SetActive(true);
        foreach (var item in _uiElements)
        {
            if (_uiElements.ContainsKey("MainMenu"))
            {
                item.Value.SetActive(false);
                _uiElements["Pause"].SetActive(true);
            }
        }
    }

    private void BackToMenu()
    {
        _world.SetActive(true);
        foreach (var item in _uiElements)
        {
            if (_uiElements.ContainsKey("MainMenu"))
            {
                item.Value.SetActive(true);
                _world.SetActive(false);
                _uiElements["Pause"].SetActive(false);
                _uiElements["SettMenu"].SetActive(false);
            }
        }
    }
    private void SettingStop()
    {
        _uiElements["Settings"].SetActive(true);
        if (_uiElements.ContainsKey("SettMenu"))
        {
            foreach (var item in _uiElements)
            {
                item.Value.SetActive(false);
            }
            _world.SetActive(false);
            _uiElements["SettMenu"].SetActive(true);
            _uiElements["Sound"].SetActive(true);
            _uiElements["Music"].SetActive(true);
            _uiElements["BackToPlay"].SetActive(true);
            _uiElements["BackToMenu"].SetActive(true);
        }  
    }

    public void EnableWorld()
    {
        _world.SetActive(true);
        foreach (var item in _uiElements)
        {
            if (_uiElements.ContainsKey("MainMenu"))
            {
                item.Value.SetActive(false);
                _uiElements["Pause"].SetActive(true);
            }
        }   
    }

    private void Exit()
    {
        Application.Quit();
    }
}