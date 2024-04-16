using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : EnemyMove
{
    [SerializeField] private Text eHP;
    int currentHp;

    private void Start()
    {
        currentHp = ChangeHP();
    }

    private void Update()
    {
        eHP.text = $"Enemy HP : {currentHp}";
    }
}
