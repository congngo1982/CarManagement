using BusinessObject.Models;

namespace DataAccess.Repository
{
    public interface IMember
    {
        public Member GetMember(string username);
    }
}
