using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Tournament;
using SWD.SportShirtShop.Services.RequetsModel.TournamentClub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Service
{
    public class TournamentClubService : ITournamentClubService
    {
        private readonly UnitOfWork _unitOfWork;
        public TournamentClubService(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }


        public async Task<IBusinessResult> GetAll()
        {
            var item = await _unitOfWork.TournamentClub.GetAllAsync();
            if (item != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, item);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var item = await _unitOfWork.TournamentClub.GetByIdAsync(id);
            if (item == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, item);
            }
        }

        public Task<IBusinessResult> Save(Club club)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> UpdateTournarmentClub(TournamentClubUpdateRequest tournamentClubUpdateRequest)
        {
            try
            {
                int result = -1;
                var tournament = _unitOfWork.Tournament.GetById(tournamentClubUpdateRequest.Id);

                if (tournament != null)
                {
                    _unitOfWork.Tournament.Context().Entry(tournament).CurrentValues.SetValues(tournamentClubUpdateRequest);
                    result = await _unitOfWork.Tournament.UpdateAsync(tournament);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, tournament);
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
        public async Task<IBusinessResult> CreateTournarmentClub(TournamentClubCreateRequest tournamentClubCreateRequest)
        {
            try
            {
                int result = -1;
                TournamentClub newTournament = new TournamentClub
                {
                    Id = tournamentClubCreateRequest.Id,
                    IdClub = tournamentClubCreateRequest.IdClub,
                    IdTournament = tournamentClubCreateRequest.IdTournament,
                    CreateDate = DateTime.Now,
                    CreateAccount = tournamentClubCreateRequest.CreateAccount
                };


                result = await _unitOfWork.TournamentClub.CreateAsync(newTournament);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, newTournament);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, newTournament);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var tournamentClub = await _unitOfWork.TournamentClub.GetByIdAsync(id);
                if (tournamentClub == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    var result = await _unitOfWork.TournamentClub.RemoveAsync(tournamentClub);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, tournamentClub);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, tournamentClub);
                    }

                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }
    }
}
