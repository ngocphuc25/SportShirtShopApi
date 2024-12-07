using Microsoft.EntityFrameworkCore.Metadata;
using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Image;
using SWD.SportShirtShop.Services.RequetsModel.PlayerInTournamentClub;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Service
{
    public class PlayerInTournamentClubService : IPlayerInTournamentClubService
    {
        private readonly UnitOfWork _unitOfWork;
        public PlayerInTournamentClubService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IBusinessResult> GetAll()
        {
            var query = await _unitOfWork.PlayerInTournamentClub.GetAllAsync();
            if (query != null) 
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, query);
            else return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var query = await _unitOfWork.PlayerInTournamentClub.GetByIdAsync(id);
            if (query != null) return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, query);
            else return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);

        }

        public Task<IBusinessResult> Save(PlayerInTournamentClub playerInTournamentClub)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> UpdatePlayerInTournamentClub(PlayerInTournamentClubUpdateRequest playerInTournamentClubUpdateRequest)
        {
            
            try
            {
                int result = -1;
                var image = _unitOfWork.PlayerInTournamentClub.GetById(playerInTournamentClubUpdateRequest.Id);

                if (image != null)
                {
                    _unitOfWork.PlayerInTournamentClub.Context().Entry(image).CurrentValues.SetValues(playerInTournamentClubUpdateRequest);
                    result = await _unitOfWork.PlayerInTournamentClub.UpdateAsync(image);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, image);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    return new BusinessResult(Const.SUCCESS_READ_CODE, "NOT FOUND ID");
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }

        }

        public async Task<IBusinessResult> CreatePlayerInTournamentClub(PlayerInTournamentClubCreateRequest playerInTournamentClubCreateRequest)
        {
            try
            {
                int result = -1;

                PlayerInTournamentClub newItem = new PlayerInTournamentClub
                {
                    Id = playerInTournamentClubCreateRequest.Id,
                    IdPlayer = playerInTournamentClubCreateRequest.IdPlayer,
                    IdTournamentClub = playerInTournamentClubCreateRequest.IdTournamentClub,
                    Number = playerInTournamentClubCreateRequest.Number,
                    PlayerName = playerInTournamentClubCreateRequest?.PlayerName,
                    SeasonName = playerInTournamentClubCreateRequest?.SeasonName,
                    ClubName = playerInTournamentClubCreateRequest?.ClubName,
                    Description = playerInTournamentClubCreateRequest.Description
                };


                result = await _unitOfWork.PlayerInTournamentClub.CreateAsync(newItem);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, newItem);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, newItem);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public Task<IBusinessResult> DeleteById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
