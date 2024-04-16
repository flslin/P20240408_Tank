using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : Player
{
    [SerializeField] private Text pHP;
    int currentHp;

    private void Start()
    {
        currentHp = ChangeHP();
    }

    private void Update()
    {
        pHP.text = $"Player HP : {currentHp}";
    }
}
