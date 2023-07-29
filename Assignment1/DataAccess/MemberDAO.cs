using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private IMember member;
        public MemberDAO()
        {
            if(member == null)
            {
                member = new MemberRepository();
            }
        }
        public Member CheckMember(string username, string password)
        {
            Member mem = member.GetMember(username);
            if(mem != null ) { 
            if(mem.Password != password)
                {
                    mem = null;
                }
            } else
            {
                throw new Exception("Username is Incorrect !!!");
            }
            return mem;
        }
    }
}
