using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Collections;

namespace CryptoCrew.Models
{
    public class CertModels
    {
        public X509Certificate certificate { get; set; }
    }
}