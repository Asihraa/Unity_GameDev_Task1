using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    // 1. Tiga variabel public
    public int playerHP = 100;
    public int healAmount = 20;
    public int enemyAttackPower = 30;

    // 2. Fungsi-fungsi dengan return value

    // Mengurangi HP dan mengembalikan HP terbaru
    public int TakeDamage(int damage)
    {
        playerHP -= damage;
        return playerHP;
    }

    // Menambah HP dan mengembalikan HP terbaru
    public int Heal(int amount)
    {
        playerHP += amount;
        return playerHP;
    }

    // Mengecek apakah pemain mati (HP <= 0)
    public bool IsDead()
    {
        return playerHP <= 0;
    }

    // 3. Fungsi Start untuk simulasi proses
    void Start()
    {
        Debug.Log("Player HP Awal: " + playerHP);

        int afterDamage = TakeDamage(enemyAttackPower);
        Debug.Log("HP Setelah Diserang: " + afterDamage);

        int afterHeal = Heal(healAmount);
        Debug.Log("HP Setelah Healing: " + afterHeal);

        if (IsDead())
        {
            Debug.Log("Status: Pemain Mati");
        }
        else
        {
            Debug.Log("Status: Pemain Masih Hidup");
        }
    }
}
