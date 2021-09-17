using System;
using System.Collections.Generic;

#nullable disable

namespace APICore.Data.Model
{
    public partial class ContactType
    {
        public ContactType()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Contacttypename { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
