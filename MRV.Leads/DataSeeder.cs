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
                    ContactFirstName = "John",
                    ContactFullName = "John Smith",
                    ContactPhone = "(555) 123-4567",
                    ContactEmail = "john@email.com",
                    DateCreated = DateTime.Now.AddDays(-5),
                    Suburb = "Downtown",
                    Category = "House Painting",
                    Description = "Interior painting for 3-bedroom house",
                    Price = 450,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "Maria",
                    ContactFullName = "Maria Garcia",
                    ContactPhone = "(555) 234-5678",
                    ContactEmail = "maria@email.com",
                    DateCreated = DateTime.Now.AddDays(-3),
                    Suburb = "Westside",
                    Category = "Kitchen Renovation",
                    Description = "Complete kitchen remodel with cabinets",
                    Price = 650,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "David",
                    ContactFullName = "David Wilson",
                    ContactPhone = "(555) 345-6789",
                    ContactEmail = "david@email.com",
                    DateCreated = DateTime.Now.AddDays(-2),
                    Suburb = "Northside",
                    Category = "Plumbing",
                    Description = "Fix bathroom plumbing and install new fixtures",
                    Price = 320,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "Sarah",
                    ContactFullName = "Sarah Johnson",
                    ContactPhone = "(555) 456-7890",
                    ContactEmail = "sarah@email.com",
                    DateCreated = DateTime.Now.AddDays(-4),
                    Suburb = "Eastside",
                    Category = "Roof Repair",
                    Description = "Repair roof tiles and fix gutter system",
                    Price = 720,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "Mike",
                    ContactFullName = "Mike Brown",
                    ContactPhone = "(555) 567-8901",
                    ContactEmail = "mike@email.com",
                    DateCreated = DateTime.Now.AddDays(-1),
                    Suburb = "Southside",
                    Category = "Electrical",
                    Description = "Rewire basement and install new outlets",
                    Price = 850,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "Lisa",
                    ContactFullName = "Lisa Davis",
                    ContactPhone = "(555) 678-9012",
                    ContactEmail = "lisa@email.com",
                    DateCreated = DateTime.Now.AddDays(-6),
                    Suburb = "Central",
                    Category = "Landscaping",
                    Description = "Garden design and tree trimming service",
                    Price = 280,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "Robert",
                    ContactFullName = "Robert Miller",
                    ContactPhone = "(555) 789-0123",
                    ContactEmail = "robert@email.com",
                    DateCreated = DateTime.Now.AddDays(-8),
                    Suburb = "Uptown",
                    Category = "Home Renovation",
                    Description = "Complete bathroom renovation project",
                    Price = 980,
                    Status = "New"
                },
                new Lead
                {
                    ContactFirstName = "Tom",
                    ContactFullName = "Tom Anderson",
                    ContactPhone = "(555) 890-1234",
                    ContactEmail = "tom@email.com",
                    DateCreated = DateTime.Now.AddDays(-7),
                    Suburb = "Riverside",
                    Category = "Deck Installation",
                    Description = "Build wooden deck in backyard",
                    Price = 600,
                    Status = "Accepted"
                }
            };

            context.Leads.AddRange(leads);
            context.SaveChanges();
        }
    }
}