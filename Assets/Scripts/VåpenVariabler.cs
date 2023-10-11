using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VåpenVariabler : MonoBehaviour
{
    /* fart              = Hastigheit på kuler.
     * maxRekevidde      = Rekevidda til våpenet.
     * magasinKapasitet  = Kor mange kuler som du kan skyte før du må lade på nytt.
     * angrepHastigheit  = Kor raskt det skal ta mellom angrepene.
     * 
     * skade             = Skade våpene gjer:
     *      Skytevåpen: Kuleskade. 
     *      Fysiske våpen: Skade på kontakt
     *      
     * 
     * skyteModus        = Korleis skytevåpene skyter:
     *      1: Full automatisk.
     *      2: Semi automatisk.
     *      3: Laser.
     *      
     * kulaBrukt         = Kva kula våpene bruker. 
     *                     Denne variablen skal vere indexen til kula våpene bruker frå kuleList listo frå SkytevåpenSkriptet.
     *                     
     * treffEffekt       = Dette er kva partikkel effekt som blir brukt når våpenes hitbox/kuler treffer noko.
     */

    public float fart = 10;
    public float maxRekevidde = 10;
    public float skade = 10;
    public float magasinKapasitet = 10;
    public float angrepHastigheit = 0.1f;
    public float tilbakeslagKraft = 30;
    public int skyteModus = 0;
    public int kulaBrukt = 0;

    public ParticleSystem treffEffekt;
}
