using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gem : MonoBehaviour
{
// The amount of gems this pickup is worth
public int gemValue = 1;
private void OnTriggerEnter2D(Collider2D other)
{
if (other.CompareTag("Player"))
{
// Add gemValue to the player's gem count
GemsManager.instance.IncreaseGems(gemValue);
// Destroy the gem object
Destroy(gameObject);
}
}
}