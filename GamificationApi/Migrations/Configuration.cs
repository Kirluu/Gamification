using System.Collections.Generic;
using GamificationApi.Models;

namespace GamificationApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GameContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GameContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            // Hardcoded general stats - could be named differently in future game-generation fds
            var willpower = new GeneralStat
            {
                Name = "Willpower",
                StatEffect = new StatEffect { AffectedStatBonus = AffectedStatBonus.Exp, Multiplier = 0.1 },
                Amount = 1.00
            };
            var charisma = new GeneralStat
            {
                Name = "Charisma",
                StatEffect = new StatEffect { AffectedStatBonus = AffectedStatBonus.JobPoints, Multiplier = 0.001 },
                Amount = 1.00
            };
            var intelligence = new GeneralStat
            {
                Name = "Intelligence",
                StatEffect = new StatEffect { AffectedStatBonus = AffectedStatBonus.GeneralStats, Multiplier = 0.01 },
                Amount = 1.00
            };
            var perception = new GeneralStat
            {
                Name = "Perception",
                StatEffect = new StatEffect { AffectedStatBonus = AffectedStatBonus.AllRewards, Multiplier = 0.0001 },
                Amount = 1.00
            };
            context.GeneralStats.AddOrUpdate(x => x.Id, willpower, charisma, intelligence, perception);

            // Initial test player
            context.Players.AddOrUpdate(x => x.Id, new Player
            {
                Name = "Admin",
                Experience = 255,
                JobPoints = 2000,
                Level = 1,
                Title = "Newbie",
                GeneralStats = new List<GeneralStat>
                {
                    willpower,
                    charisma,
                    intelligence,
                    perception
                },
                Achievements = new List<Achievement>(),
                AssignmentsCompleted = new List<Assignment>(),
                JobPointPurchases = new List<JobPointPurchase>()
            });

            // Level-ups
            context.Levels.AddOrUpdate(x => x.Id, new Level
            {
                LevelNumber = 2,
                Title = "Newbie",
                ExperienceReq = 100,
                AchievementsReq = new List<Achievement>(),
                GeneralStatsReq = new List<GeneralStat>(),
                JobPointReward = 20
            },
            new Level
            {
                LevelNumber = 3,
                Title = "Dedicated newbie",
                ExperienceReq = 250,
                AchievementsReq = new List<Achievement>(),
                GeneralStatsReq = new List<GeneralStat>(),
                JobPointReward = 30
            });
        }
    }
}
