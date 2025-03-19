namespace LibrarieModele
{
    public class Vehicul
    {
        public string NumarInmatriculare { get; set; }
        public TipVehicul Tip { get; set; }

        public Vehicul(string numarInmatriculare, TipVehicul tip)
        {
            NumarInmatriculare = numarInmatriculare;
            Tip = tip;
        }

        public override string ToString()
        {
            return $"{Tip} - {NumarInmatriculare}";
        }
    }
}
