﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SWD.SportShirtShop.Repo.Entities;

public partial class ShirtEdition
{
    public int Id { get; set; }

    public int? IdTournamentClub { get; set; }

    public string Nameseason { get; set; }

    public string Color { get; set; }

    public string Material { get; set; }

    public string VersionForMatch { get; set; }

    public string Status { get; set; }

    public string Note { get; set; }

    public string Code { get; set; }

    public DateTime? CreateDate { get; set; }

    public int? CreateAccount { get; set; }
    [JsonIgnore]
    public virtual TournamentClub IdTournamentClubNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<Shirt> Shirts { get; set; } = new List<Shirt>();
}