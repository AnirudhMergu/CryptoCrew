using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Collections;

namespace CryptoCrew.Cryptography
{
    public class X509Certificates
    {
        public string Email = MembershipStatus.getUser().Email;

       
    }

    public class MembershipStatus
    {
        public static MembershipUser getUser()
        {
            return Membership.GetUser();
        }
    }
}