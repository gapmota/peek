using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft;
using Newtonsoft.Json;
using peekapi.Models;

namespace peekapi.controller
{
    public class ToJSON
    {
        public string getUsuarioToJson()
        {
            List<Usuario> l = new List<Usuario>();

            Usuario u = new Usuario();
            u.Email = "m@m.com";
            u.Nome = "aaa";
            u.Id = 12;

            l.Add(u);


            u = new Usuario();
            u.Email = "C@m.com";
            u.Nome = "Cc";
            u.Id = 10;

            l.Add(u);


            u = new Usuario();
            u.Email = "c@m.com";
            u.Nome = "bb";
            u.Id = 11;

            l.Add(u);

            return JsonConvert.SerializeObject(l);
        }

        public List<Usuario> JsonToListUsuario(string json)
        {
            JsonConvert.DeserializeObject(json);

            List<Usuario> list = JsonConvert.DeserializeObject<List<Usuario>>(json);
            
            return list;
        }

    }
}