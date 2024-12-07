﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SWD.SportShirtShop.Repo.Entities;

public partial class Order
{
    public int Id { get; set; }

    public string Note { get; set; }

    public string Status { get; set; }

    public int? IdAccount { get; set; }

    public string PaymentMethod { get; set; }

    public string PaymentStatus { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string ShipAddress { get; set; }

    public decimal? TotalAmmount { get; set; }

    public string Code { get; set; }

    public DateTime? CreateDate { get; set; }
    [JsonIgnore]
    public virtual Account IdAccountNavigation { get; set; }
 
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    [JsonIgnore]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}