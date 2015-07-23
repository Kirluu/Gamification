using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamificationApi.Models
{
    public class GeneralStat : IComparable
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public StatEffect StatEffect { get; set; }
        public double Amount { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var comparedTo = obj as GeneralStat;
            if (comparedTo != null)
            {
                if (StatEffect.AffectedStatBonus == comparedTo.StatEffect.AffectedStatBonus && Name == comparedTo.Name)
                {
                    if (Amount < comparedTo.Amount) return -1;
                    if (Amount > comparedTo.Amount) return 1;
                    return 0;
                }
                else
                {
                    throw new ArgumentException("GeneralStats do not regard the same stat!");
                }
            }
            else
            {
                throw new ArgumentException("Object is not a GeneralStat!");
            }
        }
    }
}