using amazen_server.Repositories;
using amazen_server.Models;

namespace amazen_server.Services
{
    public class ProfileService
    {
        private readonly ProfileRepository _repo;
        public ProfileService(ProfileRepository repo)
        {
            _repo = repo;
        }
    }
}