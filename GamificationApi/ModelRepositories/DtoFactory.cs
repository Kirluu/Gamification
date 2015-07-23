using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamificationApi.Dtos;
using GamificationApi.Models;

namespace GamificationApi.ModelRepositories
{
    public class DtoFactory : IDtoFactory
    {
        private readonly IUnitOfWork _unitOfWork;
        public DtoFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PlayerDto CreatePlayerDto(Player player)
        {
            // General stat DTOs
            var generalStatDtos = player.GeneralStats.Select(generalStat => CreateGeneralStatDto(generalStat, true)).ToList();

            // Assignment DTOs
            var assignmentTypes = _unitOfWork.AssignmentTypeRepository.Get(null, null, "");
            var assignmentDtos = assignmentTypes.Select(assignmentType => CreateAssignmentDto(player, assignmentType)).ToList();

            // Achievement DTOs
            var achievements = _unitOfWork.AchievementRepository.Get(null, null, "");
            var achievementDtos = achievements.Select(CreateAchievementDto).ToList();

            // Job point purchase DTOs
            var jobPointPurchaseDtos =
                player.JobPointPurchases.Select(CreateJobPointPurchaseDto).ToList();

            // Use other Dtos to create final PlayerDto
            return new PlayerDto
            {
                Name = player.Name,
                Experience = player.Experience,
                Level = player.Level,
                Title = player.Title,
                JobPoints = player.JobPoints,
                GeneralStats = generalStatDtos,
                AssignmentsCompleted = assignmentDtos,
                Achievements = achievementDtos,
                JobPointPurchases = jobPointPurchaseDtos
            };
        }

        public GeneralStatDto CreateGeneralStatDto(GeneralStat generalStat, bool arePlayerValues)
        {
            string statEffect;
            if (!arePlayerValues) // Provide general descriptions
            {
                switch (generalStat.StatEffect.AffectedStatBonus)
                {
                    case AffectedStatBonus.AllRewards:
                        statEffect = "Applies a bonus to all reward types";
                        break;
                    case AffectedStatBonus.GeneralStats:
                        statEffect = "Applies a bonus to all general stat rewards";
                        break;
                    case AffectedStatBonus.JobPoints:
                        statEffect = "Applies a bonus to job point rewards";
                        break;
                    case AffectedStatBonus.Exp:
                        statEffect = "Applies a bonus to experience rewards";
                        break;
                    default:
                        statEffect = ""; // Shouldn't be the case, due to fixed enum, but if expanded, just contain empty string
                        break;
                }
            }
            else // A player's general stat amounts
            {
                switch (generalStat.StatEffect.AffectedStatBonus)
                {
                    case AffectedStatBonus.AllRewards:
                        var allRewBonus = generalStat.Amount * generalStat.StatEffect.Multiplier;
                        statEffect = "Applies a " + allRewBonus + " % bonus to all reward types";
                        break;
                    case AffectedStatBonus.GeneralStats:
                        var genStatBonus = generalStat.Amount * generalStat.StatEffect.Multiplier;
                        statEffect = "Applies a " + genStatBonus + " % bonus to all general stat rewards";
                        break;
                    case AffectedStatBonus.JobPoints:
                        var jobPtBonus = generalStat.Amount * generalStat.StatEffect.Multiplier;
                        statEffect = "Applies a " + jobPtBonus + " % bonus to job point rewards";
                        break;
                    case AffectedStatBonus.Exp:
                        var expBonus = generalStat.Amount * generalStat.StatEffect.Multiplier;
                        statEffect = "Applies a " + expBonus + " % bonus to experience rewards";
                        break;
                    default:
                        statEffect = ""; // Shouldn't be the case, due to fixed enum, but if expanded, just contain empty string
                        break;
                }
            }

            var generalStatDto = new GeneralStatDto
            {
                Name = generalStat.Name,
                StatEffect = statEffect,
                Amount = generalStat.Amount
            };

            return generalStatDto;
        }

        public AssignmentDto CreateAssignmentDto(Player player, AssignmentType assignmentType)
        {
            var amount = // Amount of assignments completed of the given type
                player.AssignmentsCompleted.FindAll(ass => ass.Type.NameOrCode == assignmentType.NameOrCode).Count;

            var generalStatDtos = assignmentType.GeneralStatRewards.Select(generalStat => CreateGeneralStatDto(generalStat, false)).ToList();

            return new AssignmentDto
            {
                TypeOrName = assignmentType.NameOrCode,
                Amount = amount,
                ExpReward = assignmentType.ExpReward,
                GeneralStatRewards = generalStatDtos
            };
        }

        public AchievementDto CreateAchievementDto(Achievement achievement)
        {
            // Assignment type req DTOs
            var assignmentTypeReqDtos =
                achievement.AssignmentTypeReqs.Select(CreateAssignmentTypeReqDto).ToList();
            // General stat req DTOs
            var generalStatReqDtos = achievement.GeneralStatReqs.Select(generalStat => CreateGeneralStatDto(generalStat, false)).ToList();
            // Job point purchase req DTOs
            var jobPointProductReqDtos = achievement.JobPointProductReqs.Select(CreateJobPointProductDto).ToList();
            // General stat reward DTOs
            var generalStatRewards = achievement.GeneralStatRewards.Select(generalStat => CreateGeneralStatDto(generalStat, false)).ToList();

            return new AchievementDto
            {
                AssignmentTypeReqs = assignmentTypeReqDtos,
                GeneralStatReqs = generalStatReqDtos,
                JobPointProductReqs = jobPointProductReqDtos,
                JobPointReward = achievement.JobPointReward,
                GeneralStatRewards = generalStatRewards
            };
        }

        public AssignmentTypeReqDto CreateAssignmentTypeReqDto(AssignmentTypeReq assignmentTypeReq)
        {
            var generalStatDtos = assignmentTypeReq.AssignmentType.GeneralStatRewards.Select(generalStat => CreateGeneralStatDto(generalStat, false)).ToList();

            return new AssignmentTypeReqDto
            {
                AssignmentType = new AssignmentTypeDto
                {
                    NameOrCode = assignmentTypeReq.AssignmentType.NameOrCode,
                    ExpReward = assignmentTypeReq.AssignmentType.ExpReward,
                    GeneralStatRewards = generalStatDtos
                },
                AmountReq = assignmentTypeReq.AmountReq
            };
        }

        public JobPointPurchaseDto CreateJobPointPurchaseDto(JobPointPurchase jobPointPurchase)
        {
            return new JobPointPurchaseDto
            {
                Product = CreateJobPointProductDto(jobPointPurchase.Product),
                DateAndTime = jobPointPurchase.DateAndTime,
                Claimed = jobPointPurchase.Claimed
            };
        }

        public JobPointProductDto CreateJobPointProductDto(JobPointProduct jobPointProduct)
        {
            return new JobPointProductDto
            {
                Name = jobPointProduct.Name,
                Description = jobPointProduct.Description,
                Cost = jobPointProduct.Cost
            };
        }
    }
}