using LoveFirst.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace LoveFirst.Models
{
    public interface IRepository
    {
        int GetTotalScore(int profileId);
        IEnumerable<OperationsViewModel> GetOperations(int counterId);
        IEnumerable<Participants> GetParticipants(int counterId);
        IEnumerable<Profiles> FindByLogin(string login);
        int GetCounterId(int profileId);
        void AddPoint(int participantId, int counterId);
        void CreateProfile(string login, string passwordHash);
    }
}
