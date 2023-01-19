
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPBar : MonoBehaviour
{
    private HPManager _hPManager;
    [SerializeField]
    private Transform _heartImagePool;
    [SerializeField]
    private Transform _heartImagePrefab;
    [SerializeField]
    private List<Transform> hearts=new();
    [SerializeField]
    private TMP_Text _tMP_Text;

    private Vector3 _offsetHeartPos = new Vector3(100f, 0);
    private void Awake()
    {
        _hPManager=FindObjectOfType<HPManager>();
        _tMP_Text=GetComponentInChildren<TMP_Text>();
        _hPManager.hPDraw += DrawHP;
    }

    private void DrawHP(int hp)
    {
        _tMP_Text.text = "<size=36> <color=red>Amount HP:" + hp + " </color></size>";

        Transform temp = default; 
        if(hearts.Count > 0)
            temp=hearts.Last(t =>t.gameObject.activeSelf);
        if(temp!=default)
        {
            temp.gameObject.SetActive(false);
        }
        else
        {
            while (hearts.Count < hp)
            {
                PoolUp(true);
            }
        }


    }

    private Transform PoolUp(bool isActive)
    {
        var element = Instantiate(_heartImagePrefab);
        element.transform.SetParent(_heartImagePool);
        element.transform.localPosition= _offsetHeartPos* hearts.Count;
        element.gameObject.SetActive(isActive);
        hearts.Add(element);
        return element;
    }
}
