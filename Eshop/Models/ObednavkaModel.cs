namespace Eshop.Models
{
    public class ObednavkaModel
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string SlunecniSoustava { get; set; }
        public string Planeta { get; set; }
        public string Mesto { get; set; }
        public string Ulice { get; set; }
        public string CisloDomu {  get; set; }
        public string PSC { get; set; }
        public string SoustavaDoruceni { get; set; }
        public string ZpusobPlatby { get; set; }
        public string GUID { get; set; }
        public string IdKos {  get; set; }

        public ObednavkaModel()
        {
            Id = 0;
            Jmeno = "";
            Prijmeni = "";
            SlunecniSoustava = "";
            Planeta = "";
            Mesto = "";
            Ulice = "";
            CisloDomu = "";
            PSC = "";
            SoustavaDoruceni = "";
            ZpusobPlatby = "";
            GUID = "";
            IdKos = "";
        }
    }
}
