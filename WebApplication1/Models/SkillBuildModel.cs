using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SkillBuildModel
    {
        [Key]
        public int id{ get; set; }
        [Range(1, 4, ErrorMessage = "Please choose a valid priority(1-4)")]
        public int Skill1Prio { get; set; }
        [Range(1, 4, ErrorMessage = "Please choose a valid priority(1-4)")]
        public int Skill2Prio { get; set; }
        [Range(1, 4, ErrorMessage = "Please choose a valid priority(1-4)")]
        public int Skill3Prio { get; set; }
        [Range(1, 4, ErrorMessage = "Please choose a valid priority(1-4)")]
        public int UltiPrio { get; set; }
    }
}