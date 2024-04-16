using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] private Text playerHP;
    [SerializeField] private Text enemyHP;
    Player player;
    EnemyMove enemy;

    private void Start()
    {
    }

    void Update()
    {
        playerHP.text = GetComponent<Player>().playerHP.ToString();
        enemyHP.text = GetComponent<EnemyMove>().enemyHP.ToString();
    }
}
