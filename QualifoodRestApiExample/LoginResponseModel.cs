namespace QualifoodRestApiExample
{
    public class LoginResponseModel 
    {
        public string Token { get; set; }
        public string BenutzerId { get; set; }
        public bool DatenschutzerklaerungAkzeptiert { get; set; }
        public string TeilnehmerName { get; set; }
        public string Betriebsnummer { get; set; }
    }
}