﻿using Proiect_PSSC.Application.Workflows;
using Proiect_PSSC.Domain.Entities;
using Proiect_PSSC.Domain.Interfaces;
using Proiect_PSSC.Domain.Services;
using Proiect_PSSC.Infrastructure.Repositories;
using Proiect_PSSC.Infrastructure.Database;

namespace Proiect_PSSC.Program;

class Program
{
    static async Task Main(string[] args)
    {
        var dbContext = new AppDBContext();
        var produsRepository = new ProdusRepository(dbContext);
        var comandaService = new ServiceComanda(produsRepository);
        var workflow = new WorkflowPlasareComanda(comandaService);

        //introducere de date provizorie
        var produse = new List<Produs>
        {
            dbContext.Produse[0],
            dbContext.Produse[1]
        };
        
        var comanda = await workflow.ProceseazaComanda(produse);
        
        Console.WriteLine($"Status comanda: {comanda.Status},Produse: {comanda.Produse} si Pret total: {comanda.PretTotal}");
    }
}

