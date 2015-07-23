using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamificationApi.Dtos;
using GamificationApi.Models;

namespace GamificationApi.ModelRepositories
{
    public interface IDtoFactory
    {
        PlayerDto CreatePlayerDto(Player player);
    }
}
