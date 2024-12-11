﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SWD.SportShirtShop.Repo.Entities;

public partial class Club
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Logo { get; set; }

    public string Status { get; set; }

    public string Note { get; set; }

    public string Code { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateAccount { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<TournamentClub> TournamentClubs { get; set; } = new List<TournamentClub>();
}