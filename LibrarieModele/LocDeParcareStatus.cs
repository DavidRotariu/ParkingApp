using System;

namespace LibrarieModele
{
    [Flags]
    public enum LocDeParcareStatus
    {
        None = 0,
        Liber = 1,
        Ocupat = 2,
        Rezervat = 4,
        PentruDizabilitati = 8,
        InMentenanta = 16,
        PentruElectrice = 32,
        VIP = 64,
        Temporar = 128
    }
}