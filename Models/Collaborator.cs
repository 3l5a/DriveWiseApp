﻿using Microsoft.EntityFrameworkCore;


namespace Entities;

public class Collaborator
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<Rental> Rentals { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<Carpool> CarpoolsAsDriver { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<Carpool> CarpoolsAsPassenger { get; set; }

    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}