using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diary : MonoBehaviour
{
    private GameObject _diary;
    [SerializeField] private Canvas _uiMenu;
    private Dictionary<string, GameObject> _diaryelements = new Dictionary<string, GameObject>();
    private void Awake()
    {
        if (_uiMenu != null)
        {
            _uiMenu.gameObject.SetActive(true);
        }
        else
        {
            throw new InvalidOperationException("Canvas is not set!!");
        }
    }

    private void Start()
    {
        _diary = GameObject.FindGameObjectWithTag("Diary");
        if (_diary != null)
        {
            _diary.SetActive(true);
        }
        var diaryChilds = _uiMenu.GetComponentsInChildren<Transform>();
        for (int i = 1; i < diaryChilds.Length; i++)
        {
            if (diaryChilds[i].childCount > 0)
            {
                _diaryelements.Add(diaryChilds[i].name, diaryChilds[i].gameObject);
            }
        if (_diaryelements.ContainsKey("DiaryMenu"))
            {
                _diaryelements["DiaryMenu"].GetComponent<Button>().onClick.AddListener(EnableDiary);
            }
        if (_diaryelements.ContainsKey("DiaryStop"))
            {
                _diaryelements["DiaryStop"].SetActive(false);
            }
        if (_diaryelements.ContainsKey("BackDiary"))
            {
                _diaryelements["BackDiary"].SetActive(false);
                _diaryelements["BackDiary"].GetComponent<Button>().onClick.AddListener(BackToPlay);
            }
        }
    }

    private void BackToPlay() 
    {
        _diary.SetActive(true);
        foreach (var item in _diaryelements)
        {
            item.Value.SetActive(false);
            _diaryelements["DiaryMenu"].SetActive(true);
        }
    }


    private void EnableDiary()
    {
        _diary.SetActive(true);
        foreach (var item in _diaryelements)
        {
            item.Value.SetActive(false);
            _diaryelements["DiaryStop"].SetActive(true);
            _diaryelements["BackDiary"].SetActive(true);
        }
    }

}
