using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resposta_304817.Models
{
    public class Exemplo
    {
        [DisplayName("Tipo de usuário")]
        public List<SelectListItem> Tipo_user { get; set; }

        //public string Tipo_user
        //{
        //    get { return tipo_user; }
        //    set { tipo_user = value; }
        //}
    }
}