using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VåpenVariabler : MonoBehaviour
{
    /* ----------FLOAT----------
     * fart              = Hastigheit på kuler.
     * maxRekevidde      = Rekevidda til våpenet.
     * angrepHastigheit  = Kor raskt det skal ta mellom angrepene.
     * 
     * skade             = Skade våpene gjer:
     *      Skytevåpen: Kuleskade. 
     *      Fysiske våpen: Skade på kontakt
     *      
     * reloadFart        = Kor lang tid det tar for realoaden til å ve ferdig.
     * ----------INT----------
     * 
     * skyteModus        = Korleis skytevåpene skyter:
     *      1: Full automatisk.
     *      2: Semi automatisk.
     *      3: Laser.
     *      
     * kulaBrukt         = Kva kula våpene bruker. 
     *                     Denne variablen skal vere indexen til kula våpene bruker frå kuleList listo frå SkytevåpenSkriptet.
     * magasinKapasitet  = Kor mange kuler magasinet har plass til.
     * magasinMengdeNo   = Kor mange kuler som er i magasinet nett no.
     * 
     * ----------ANDRE----------            
     * treffEffekt       = Dette er kva partikkel effekt som blir brukt når våpenes hitbox/kuler treffer noko.
     */

    public float fart = 10;
    public float maksRekkevidde = 10;
    public float angrepHastigheit = 0.1f;
    public float skade = 10;
    public float tilbakeslagKraft = 30;
    public float reloadFart = 1;
    public int skyteModus = 0;
    public int kulaBrukt = 0;
    public int magasinKapasitet = 10;
    public int magasinMengdeNo = 0;

    public ParticleSystem treffEffekt;
}
