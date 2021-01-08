using CoronaHastaTakip.Web.Areas.Admin.Models.HastaViewModels;
using CoronaHastaTakip.Web.Areas.Admin.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.Areas.Admin.Models.IsEmriViewModels
{
    public class GorevlendirEkipListViewModel
    {
        public HastaListViewModel Hasta { get; set; }
        public AppUserListViewModel AppUser { get; set; }
    }
}
