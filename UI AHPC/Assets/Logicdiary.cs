using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logicdiary : MonoBehaviour
{
    public GameObject[] description;
    public GameObject quest_diary;
    [SerializeField] private Canvas diary;
    public Dictionary<string, GameObject> diary_elements = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (diary != null)
        {
            diary.gameObject.SetActive(true);
        }

        else
        {
            throw new InvalidOperationException("Canvas is not set!!");
        }
    }

    private void Start()
    {
        quest_diary = GameObject.FindGameObjectWithTag("QuestDiary");
    }

    //void ...()
    //{
    //    for (int i = 0; i < description.Length; i++)
    //    {

    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
