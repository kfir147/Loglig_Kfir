using Loglig_Kfir.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loglig_Kfir.DataAccess
{
    public class PlayersController : Controller
    {
        DataAccess da = new DataAccess();

        // GET: Players
        public ActionResult Index()
        {
            return View("PlayersList");
        }

        public ActionResult PlayersScreen()
        {

            List<Players> playersList = (from p in da.Players
                                         select p).ToList<Players>();

            if (playersList.Count > 0)
            {
                PlayersList list = new PlayersList();
                //list.ID = 1;
                list.playersList = playersList;


                return View(list);
            }
            else
            {
                PlayersList list = new PlayersList();
                return View(list);
            }
        }

        public ActionResult CreatePlayer(string fname, string lname, string email)
        {
            //checking if the given mail already exist (by email)
            List<Players> list = (from p in da.Players
                                  where (p.Email.Equals(email))
                                  select p).ToList<Players>();
            //if it doesn't exist, then we will add
            if (list.Count == 0)
            {
                da.Players.Add(new Players { FirstName = fname, LastName = lname, Email = email });
                da.SaveChanges();
                TempData["Message"] = "השחקן נוצר בהצלחה";
                return RedirectToAction("PlayersScreen");
            }
            //otherwise we will send an error message
            else
            {
                TempData["Message"] = "המייל שהזנת כבר קיים במערכת, אנא בחר מייל אחר.";
                return RedirectToAction("PlayersScreen");
            }
        }

        public ActionResult RemovePlayer(int id)
        {
            //removing the player by his ID value, he must exists in the database.
            Players player = da.Players.Single<Players>(p => p.Id == id);
            da.Players.Remove(player);
            da.SaveChanges();
            TempData["Message"] = "השחקן נמחק בהצלחה";
            return RedirectToAction("PlayersScreen");
        }

        public ActionResult UpdatePlayer(int id, string new_fname, string new_lname, string new_email)
        {
            //checking if the new info of the player already exists (by firstName, lastName, and email)
            List<Players> list = (from p in da.Players
                                  where (p.FirstName.Equals(new_fname) && p.LastName.Equals(new_lname) && p.Email.Equals(new_email))
                                  select p).ToList<Players>();
            //if it doesn't exist, then we will update
            if (list.Count == 0)
            {
                //checking if the mail already exists in the database
                List<Players> mailList = (from p in da.Players
                                      where (p.Email.Equals(new_email) && !p.Id.Equals(id))
                                      select p).ToList<Players>();
                if (mailList.Count == 0)
                {
                    Players player = da.Players.Single<Players>(p => p.Id == id);
                    player.FirstName = new_fname;
                    player.LastName = new_lname;
                    player.Email = new_email;
                    da.SaveChanges();
                    TempData["Message"] = "השחקן עודכן בהצלחה";
                    return RedirectToAction("PlayersScreen");
                }
                else
                {
                    TempData["Message"] = "המייל שהזנת כבר קיים במערכת, אנא נסה מייל אחר.";
                    return RedirectToAction("PlayersScreen");
                }
            }
            else
            {
                TempData["Message"] = "הפרטים הללו כבר קיימים במאגר הנתונים ולכן לא קיימת אפשרות לעדכן.";
                return RedirectToAction("PlayersScreen");
            }
        }
    }
}
 