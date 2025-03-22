namespace LFTV.Models
{
    public class Contenu
    {
        public int Id { get; set; }
        public string ContenuNom { get; set; }
        public string Lien { get; set; }
        public string Type { get; set; }
        public string Statut { get; set; }
        public string Commentaire { get; set; }
        public int? EmissionId { get; set; }
        public Emission Emission { get; set; }
    }
}
