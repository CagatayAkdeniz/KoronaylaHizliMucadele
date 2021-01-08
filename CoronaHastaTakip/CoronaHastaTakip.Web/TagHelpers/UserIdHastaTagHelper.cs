using CoronaHastaTakip.Entities.Concrete;
using CoronaHastaTakipTaslak.Business.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaHastaTakip.Web.TagHelpers
{
    [HtmlTargetElement("UserIdHastaGetir")]
    public class UserIdHastaTagHelper: TagHelper
    {
        private IHastaService _hastaService;
        public UserIdHastaTagHelper(IHastaService hastaService)
        {
            _hastaService = hastaService;
        }

        public int AppUserId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Hasta> hastalar = _hastaService.GetirileAppUserId(AppUserId);

            var tamamlananHastaSayisi = hastalar.Where(x => x.Durum).Count();
            var gorevdeOlduguHastaSayisi = hastalar.Where(x => !x.Durum).Count();

            string data = "<strong>Tamamladığı Hasta Sayısı: </strong>" + tamamlananHastaSayisi +
             "<br><br> <strong>Aktif Hasta Sayısı: </strong>" + gorevdeOlduguHastaSayisi;

            output.Content.SetHtmlContent(data);
        }
    }
}
