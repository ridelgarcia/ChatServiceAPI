using System;

#nullable disable

namespace APICore.Data.Model
{
    public partial class Reservation
    {
        public int Id { get; set; }
        public DateTime Birthdate { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
        public int Contacttypeid { get; set; }

        public virtual ContactType Contacttype { get; set; }
    }
}