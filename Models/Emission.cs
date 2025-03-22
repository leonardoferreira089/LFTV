namespace LFTV.Models
{
    public class Emission
    {
        public int Id { get; set; }
        public string EmissionNom { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        public string JourDeLaSemaine { get; set; }
        public ICollection<Contenu> Emissions { get; set; } 
    }
}
