using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShowText : MonoBehaviour
{
    public uint index = 0;
    public theWASlimetationsWASandWASpowersWASthatWAStheDMessentualWAScontanes gameController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.DisplayMessage(index);
        }
    }
}
