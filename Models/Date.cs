﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities;

public class Date
{
    [Key]
    public DateTime DayAndTime { get; set; }

    public List<Carpool> Carpools { get; set; }

    [ForeignKey("StartDateId")]
    public List<Rental> RentalStarts { get; set; }

    [ForeignKey("EndDateId")]
    public List<Rental> RentalEnd { get; set; }
}