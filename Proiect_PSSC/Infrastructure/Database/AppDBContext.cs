using Proiect_PSSC.Domain.Entities;

namespace Proiect_PSSC.Infrastructure.Database;

public class AppDBContext
{
    public List<Produs> Produse { get; set; }

    public AppDBContext()
    {
        // Inițializare date mock
        Produse = new List<Produs>
        {
            new Produs(Guid.NewGuid(), "Produs1", 100m, 10),
            new Produs(Guid.NewGuid(), "Produs2", 50m, 20)
        };
    }
}