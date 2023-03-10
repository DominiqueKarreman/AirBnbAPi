﻿namespace Api.Model
{
   public class Customer
   {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
      public List<Reservation> Reservations { get; set; }

      public Customer()
      {
         Reservations = new List<Reservation>();
      }
   }
}
