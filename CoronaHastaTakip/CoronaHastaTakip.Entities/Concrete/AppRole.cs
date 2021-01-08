using CoronaHastaTakip.Entities.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHastaTakip.Entities.Concrete
{
    public class AppRole: IdentityRole<int>, IEntity
    {
    }
}
