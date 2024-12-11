﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SWD.SportShirtShop.Repo.Entities;

public partial class Tournament
{
    public int Id { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string Name { get; set; }

    public string Status { get; set; }

    public string Description { get; set; }

    public string Note { get; set; }

    public string Code { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateAccount { get; set; }

    public virtual ICollection<ShirtEdition> ShirtEditions { get; set; } = new List<ShirtEdition>();

    public virtual ICollection<TournamentClub> TournamentClubs { get; set; } = new List<TournamentClub>();
}