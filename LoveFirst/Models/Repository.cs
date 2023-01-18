using System;
using System.Collections.Generic;
using System.Linq;

namespace LoveFirst.Models
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public int GetTotalScore(int profileId)
        {
            return _context.Counters.Where(x => x.ProfileId == profileId).Select(x => x.TotalScores).FirstOrDefault();
        }

        public IEnumerable<Operations> GetOperations(int counterId)
        {
            return _context.Operations.Where(x => x.CounterId == counterId);
        }

        public IEnumerable<Participants> GetParticipants(int counterId)
        {
            return _context.Participants.Where(x => x.CounterId == counterId);
        }

        public IEnumerable<Profiles> FindByLogin(string login)
        {
            return _context.Profiles.Where(x => x.Login == login);
        }

        public int GetCounterId(int profileId)
        {
            return _context.Counters.Where(x => x.ProfileId == profileId).Select(x => x.CounterId).FirstOrDefault();
        }

        public void AddPoint(int participantId, int counterId)
        {
            Operations operation = new Operations { CounterId = counterId, ParticipantId = participantId, Score = 1, DateOperation = DateTime.Now };

            using (_context)
            {
                var participant = _context.Participants.SingleOrDefault(x => x.ParticipantId == participantId);
                if (participant != null)
                {
                    participant.NumberScore += 1;
                    _context.SaveChanges();
                }

                _context.Operations.Add(operation);

                var counter = _context.Counters.SingleOrDefault(x => x.CounterId == counterId);
                if (counter != null)
                {
                    counter.TotalScores += 1;
                    _context.SaveChanges();
                }
            }
        }
    }
}