using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Proiect_Medii_Masaj.Models
{
    public class ListClient
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(AppointmentList))]
        public int AppointmentListID { get; set; }
        public int ClientID { get; set; }
    }
}
