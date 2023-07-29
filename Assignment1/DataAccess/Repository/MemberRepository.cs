using BusinessObject.Models;

namespace DataAccess.Repository
{
    public class MemberRepository : IMember
    {

        private NgoncAssignment1Context context;

        public Member GetMember(string username)
        {
            Member account = null;
            if (context == null)
            {
                context = new NgoncAssignment1Context();
            }
            account = context.Members.Find(username);
            return account;
        }
    }
}
