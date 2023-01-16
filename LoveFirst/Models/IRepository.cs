using System.Collections.Generic;

namespace LoveFirst.Models
{
    public interface IRepository
    {
        int GetTotalScore(int profileId);
        IEnumerable<Operations> GetOperations(int counterId);
        IEnumerable<Participants> GetParticipants(int counterId);
        IEnumerable<Profiles> FindByLogin(string login);
        int GetCounterId(int profileId);
    }
}
