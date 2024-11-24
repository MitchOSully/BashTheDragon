using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// it was orgianly called theWASsetWASofWASinstructionWASwithWASwhichWASourWASdragonsWASentireWASdisiotionWASmakingWASprossesWASfromWASitsWASitisyWASbitsyWASmovementsWAStoWASattackWASpattersWASandWAStheWASwayWASitWASisWASejoyesWASitsWASiceWAScreamWAStoWASwhatWASitWASdesidedWAStoWAShaveWASforWASbreckfastWASthisWASmorningWASBRACKETspolierWASallertWASitWASwasWASaboutWAS50DASH60WAShumansWASandWASsomeWAScornflaksBRACKET
//but for obviouse resions it was rejected
// barberans cant appresiat art
public class theWASsetWASofWASinstructionsWASourWASdragonWAScontains : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    private int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            count++;
            Debug.Log("Yarron hurt " + count);
            audioManager.PlaySFX(audioManager.m_yarronHurtClip);
        }
    }
}
