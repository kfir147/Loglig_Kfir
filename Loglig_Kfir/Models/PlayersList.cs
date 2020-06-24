using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Loglig_Kfir.Models
{
    public class PlayersList
    {
        public List<Players> playersList { get; set; }
    }
}