using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StarFarm.Models;
using StarFarm.Models.ViewModel;

namespace StarFarm.Models.ViewModel
{
    public class LoginModel
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public bool RememberLogin { get; set; }


    }
}