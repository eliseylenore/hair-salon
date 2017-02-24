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

            Get["/client/new"] = _ => {
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["client_new.cshtml", AllStylists];
            };

            Post["/clients"] = _ => {
                Client newClient = new Client(Request.Form["client-name"], Request.Form["stylist-id"]);
                newClient.Save();
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
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["stylists.cshtml", AllStylists];
            };

            Get["stylist/delete/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                return View["stylist_delete.cshtml", SelectedStylist];
            };

            Delete["stylist/delete/{id}"] = parameters => {
                Stylist SelectedStylist = Stylist.Find(parameters.id);
                SelectedStylist.Delete();
                List<Stylist> AllStylists = Stylist.GetAll();
                return View["stylists.cshtml", AllStylists];
            };

        }
    }
}
