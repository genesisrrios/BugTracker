﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BugTracker.Persistance.Models
{
    [Keyless]
    public partial class UserGroup
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public byte IsAdmin { get; set; }
        public byte View { get; set; }
        public byte Edit { get; set; }
        public byte Delete { get; set; }
        public DateTimeOffset DateJoined { get; set; }
    }
}