using System;

namespace LibrarieModele
{
    public class LocDeParcare
    {
        public int Loc { get; set; }
        public LocDeParcareStatus Status { get; private set; } = LocDeParcareStatus.Liber;

        // Property to maintain backward compatibility
        public bool Ocupat
        {
            get { return Status.HasFlag(LocDeParcareStatus.Ocupat); }
            private set
            {
                if (value)
                    Status |= LocDeParcareStatus.Ocupat;
                else
                    Status &= ~LocDeParcareStatus.Ocupat;
            }
        }

        public LocDeParcare(int loc)
        {
            Loc = loc;
            Status = LocDeParcareStatus.Liber;
        }

        public LocDeParcare(int loc, bool ocupat)
        {
            Loc = loc;
            Status = ocupat ? LocDeParcareStatus.Ocupat : LocDeParcareStatus.Liber;
        }

        public LocDeParcare(int loc, LocDeParcareStatus status)
        {
            Loc = loc;
            Status = status;
        }

        public void Ocupare()
        {
            if (!Status.HasFlag(LocDeParcareStatus.Ocupat))
            {
                Status |= LocDeParcareStatus.Ocupat;
                Status &= ~LocDeParcareStatus.Liber;
            }
        }

        public void Eliberare()
        {
            if (Status.HasFlag(LocDeParcareStatus.Ocupat))
            {
                Status &= ~LocDeParcareStatus.Ocupat;
                Status |= LocDeParcareStatus.Liber;
            }
        }

        // Add additional methods for flags
        public void SetSpotStatus(LocDeParcareStatus status, bool set)
        {
            if (set)
                Status |= status;
            else
                Status &= ~status;

            // Make sure Ocupat and Liber are mutually exclusive
            if (status == LocDeParcareStatus.Ocupat && set)
                Status &= ~LocDeParcareStatus.Liber;
            else if (status == LocDeParcareStatus.Liber && set)
                Status &= ~LocDeParcareStatus.Ocupat;
        }

        public string GetInfo()
        {
            string statusText = Status.ToString();
            // If we have multiple flags, we'll get a comma-separated list of flags
            return $"Locul {Loc}: {statusText}";
        }

        // Get a more detailed status description
        public string GetDetailedStatus()
        {
            if (Status == LocDeParcareStatus.None)
                return "Nedefinit";

            string statusDetails = "";

            if (Status.HasFlag(LocDeParcareStatus.Liber))
                statusDetails += "Liber";
            if (Status.HasFlag(LocDeParcareStatus.Ocupat))
                statusDetails += (statusDetails.Length > 0 ? ", " : "") + "Ocupat";
            if (Status.HasFlag(LocDeParcareStatus.Rezervat))
                statusDetails += (statusDetails.Length > 0 ? ", " : "") + "Rezervat";
            if (Status.HasFlag(LocDeParcareStatus.PentruDizabilitati))
                statusDetails += (statusDetails.Length > 0 ? ", " : "") + "Pentru persoane cu dizabilități";
            if (Status.HasFlag(LocDeParcareStatus.InMentenanta))
                statusDetails += (statusDetails.Length > 0 ? ", " : "") + "În mentenanță";
            if (Status.HasFlag(LocDeParcareStatus.PentruElectrice))
                statusDetails += (statusDetails.Length > 0 ? ", " : "") + "Pentru vehicule electrice";
            if (Status.HasFlag(LocDeParcareStatus.VIP))
                statusDetails += (statusDetails.Length > 0 ? ", " : "") + "VIP";
            if (Status.HasFlag(LocDeParcareStatus.Temporar))
                statusDetails += (statusDetails.Length > 0 ? ", " : "") + "Temporar";

            return statusDetails;
        }
    }
}