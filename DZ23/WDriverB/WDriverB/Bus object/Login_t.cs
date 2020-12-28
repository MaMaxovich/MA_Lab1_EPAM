using System;
using System.Collections.Generic;
using System.Text;

namespace WDriverB.Bus_object
{
    class Login_t
    {


        public Login_t(string loginput_t, string passinput_t)
        {
            Loginput_t = loginput_t;
            Passinput_t = passinput_t;
        }
        public string Loginput_t { get; set; }
        public string Passinput_t { get; set; }
    }
}
