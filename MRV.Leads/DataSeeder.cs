namespace MRVLeads
{
    public static class DataSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (context.Leads.Any())
                return; // Já tem dados

            var leads = new List<Lead>
            {
                new Lead
                {
                    ContactFirstName = "João",
                    ContactFullName = "João Silva",
                    ContactPhone = "(11) 99999-1111",
                    ContactEmail = "joao@email.com",
                    DateCreated = DateTime.Now.AddDays(-5),
                    Suburb = "Vila Madalena",
                    Category = "Apartamento",
                    Description = "Apartamento 2 quartos no centro",
                    Price = 450000,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "Maria",
                    ContactFullName = "Maria Santos",
                    ContactPhone = "(11) 88888-2222",
                    ContactEmail = "maria@email.com",
                    DateCreated = DateTime.Now.AddDays(-3),
                    Suburb = "Copacabana",
                    Category = "Casa",
                    Description = "Casa com 3 quartos e quintal",
                    Price = 650000,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "Pedro",
                    ContactFullName = "Pedro Costa",
                    ContactPhone = "(11) 77777-3333",
                    ContactEmail = "pedro@email.com",
                    DateCreated = DateTime.Now.AddDays(-7),
                    Suburb = "Ipanema",
                    Category = "Cobertura",
                    Description = "Cobertura com vista para o mar",
                    Price = 800000,
                    Status = "Accepted"
                }
            };

            context.Leads.AddRange(leads);
            context.SaveChanges();
        }
    }
}