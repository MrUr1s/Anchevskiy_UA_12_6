using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPManager : MonoBehaviour
{
    [SerializeField, Tooltip("Здоровье игроков")]
    private int _hp=3;
    private int _defaultHP;

    public delegate void HPDraw(int hp);
    public HPDraw hPDraw;
    public int HP
    {
        get { return _hp; }
       private set 
        { 
            _hp = value;
            hPDraw?.Invoke(_hp);
            if (_hp <= 0)
            {
                Reset();
                Debug.Log("Проигрыш");
            }
        }
    }
    

    public void setHP(int hp = -1)
    {
        HP += hp;
    }

    public void Reset()
    {
        _hp = _defaultHP;
        FindObjectOfType<Ball>().Reset();
        LevelManager.instance.Reset();
           
    }
    private void Awake()
    {
        _defaultHP = _hp;
        hPDraw?.Invoke(_hp);
    }
}
