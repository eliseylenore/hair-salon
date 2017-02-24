using Nancy;
using System.Collections.Generic;
using HairSalon.Objects;


namespace HairSalon
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };

            Get["/clients"] = _ => {
                List<Client> AllClients = Client.GetAll();
                return View["clients.cshtml", AllClients];
            };

            Get["/stylists"] = _ => {
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["stylists.cshtml", AllStylists];
            };

            Get["/stylist/new"] = _ => {
                return View["stylist_new.cshtml"];
            };

            Post["/stylists"] = _ => {
                Stylist newStylist = new Stylist(Request.Form["stylist-name"]);
                newStylist.Save();
                return View["stylists.cshtml"];
            };
        }
    }
}
