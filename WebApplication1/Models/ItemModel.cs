using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication1.Models
{
    public class ItemModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Item Name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Item Cost is required")]
        public int cost { get; set; }
        public int damage { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int agility { get; set; }
        public int armor { get; set; }
        public int hpRegen { get; set; }
        public int attackSpeed { get; set; }
        public int health { get; set; }
        public int mana { get; set; }
        [DisplayName ("Speed")]
        public int bootSpeed { get; set; }
        public int SpeedIncrease { get; set; }
        public int ArmorReduction { get; set; }
        public float spellResistance { get; set; }
         [DisplayName("Evasion")]
        public float percentEvasion { get; set; }
         [DisplayName("Mana regen Multiplier")]
        public float percentManaRegen { get; set; }
         [DisplayName("LifeSteal")]
        public float percentLifeSteal { get; set;}
         [DisplayName("Cleave")]
        public float percentCleave { get; set; }
        public float percentMoveSpeedIncrease { get; set; }
        public bool dropsOnDeath { get; set; }

        public bool UAM { get; set; }

        



    }
}