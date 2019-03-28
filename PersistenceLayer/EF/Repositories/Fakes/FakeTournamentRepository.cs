using SportsClubModel.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersistenceLayer.EF.Repositories.Fakes
{
    public class FakeTournamentRepository
    {
        public static IDictionary<long, Tournament> data = new Dictionary<long, Tournament>();
        static FakeTournamentRepository()
        {
            data.Add(1, new Tournament
            {
                Id = 1,
                Title = "The Big Tournament",
                Level = "open",
                Start = DateTime.Today,
                End = DateTime.Today.AddDays(7),
                HasGadgets = true,
                PrizeMoney = 0
            });

            data.Add(2, new Tournament
            {
                Id = 2,
                Title = "Summer Festa",
                Level = "free for all",
                Start = DateTime.Today,
                End = DateTime.Today.AddDays(7),
                HasGadgets = true,
                PrizeMoney = 100m
            });

            data.Add(3, new Tournament
            {
                Id = 3,
                Title = "Yellow Tournament",
                Level = "beginner",
                Start = DateTime.Today,
                End = DateTime.Today.AddDays(7),
                HasGadgets = false,
                PrizeMoney = 0
            });
        }


        public IEnumerable<Tournament> All()
        {
            return data.Values;
        }

        public void Update(Tournament tournament)
        {
            data[tournament.Id] = tournament;
        }

        public void Remove(long id)
        {
            data.Remove(id);
        }

        public Tournament FindById(long id)
        {
            data.TryGetValue(id, out Tournament value);
            return value;
        }

        public Tournament Add(Tournament tournament)
        {
            data[tournament.Id] = tournament;
            return tournament;
        }

    }
}
