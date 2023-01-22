using LoveFirst.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public IEnumerable<OperationsViewModel> GetOperations(int counterId)
        {
            /*IEnumerable<OperationsViewModel> res = _context.Operations
                .Join(_context.Participants,
                    o => o.ParticipantId,
                    p => p.ParticipantId,
                    (o, p) => new OperationsViewModel { OperationId = o.OperationId, CounterId = o.CounterId, NameParticipant = p.NameParticipant, Score = o.Score, DateOperation = o.DateOperation})
                .Where(x => x.CounterId == counterId);*/

            return _context.Operations
                .Join(_context.Participants,
                    o => o.ParticipantId,
                    p => p.ParticipantId,
                    (o, p) => new OperationsViewModel { OperationId = o.OperationId, CounterId = o.CounterId, NameParticipant = p.NameParticipant, Score = o.Score, DateOperation = o.DateOperation })
                .Where(x => x.CounterId == counterId);

            /*return _context.Operations.Where(x => x.CounterId == counterId);*/
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
            using (_context)
            {
                Operations operation = new Operations { CounterId = counterId, ParticipantId = participantId, Score = 1, DateOperation = DateTime.Now };
                
                var participant = _context.Participants.SingleOrDefault(x => x.ParticipantId == participantId);
                if (participant != null)
                    participant.NumberScore += 1;

                _context.Operations.Add(operation);

                var counter = _context.Counters.SingleOrDefault(x => x.CounterId == counterId);
                if (counter != null)
                    counter.TotalScores += 1;

                _context.SaveChanges();
            }
        }

        public void CreateProfile(string login, string passwordHash)
        {
            using (_context)
            {
                Profiles profile = new Profiles { Login = login, PasswordHash = passwordHash };
                _context.Profiles.Add(profile);

                _context.SaveChanges();

                int profileId = _context.Profiles.Where(x => x.Login == login).Select(x => x.ProfileId).FirstOrDefault();
                Counters counter = new Counters { ProfileId = profileId, TotalScores = 0 };
                _context.Counters.Add(counter);

                _context.SaveChanges();
            }
        }

        public void AddParticipant(int counterId, string nameParticipant, int numberScore)
        {
            using (_context)
            {
                Participants participant = new Participants { CounterId = counterId, NameParticipant = nameParticipant, NumberScore = numberScore };
                _context.Participants.Add(participant);

                _context.SaveChanges();
            }
        }
    }
}