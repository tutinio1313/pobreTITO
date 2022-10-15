#pragma warning disable CS8618
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace pobreTITO_Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public string DNI {get; set;} = String.Empty;
    }
}