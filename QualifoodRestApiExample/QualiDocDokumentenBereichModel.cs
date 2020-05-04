namespace QualifoodRestApiExample
{
    public class QualiDocDokumentenBereichModel
    {
        public int QualiDocDokumentenBereichId { get; set; }
        public string Titel { get; set; }
        public string Beschreibung { get; set; }
        public int EmpfaengerRolleId { get; set; }
        public bool ErlaubeLoeschen { get; set; }
    }
}