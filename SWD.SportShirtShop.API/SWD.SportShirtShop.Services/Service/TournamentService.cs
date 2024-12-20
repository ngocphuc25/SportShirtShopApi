﻿using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using SWD.SportShirtShop.Services.RequetsModel.Player;
using SWD.SportShirtShop.Services.RequetsModel.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Service
{
    public class TournamentService : ITournamentService
    {
        private readonly UnitOfWork _unitOfWork;
        public TournamentService(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<IBusinessResult> GetAll()
        {
            var tournaments = await _unitOfWork.Tournament.GetAllAsync();
            if (tournaments != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, tournaments);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var tournament = await _unitOfWork.Tournament.GetByIdAsync(id);
            if (tournament == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, tournament);
            }
        }

        public async Task<IBusinessResult> Save(Tournament tournament)
        {
            try
            {
                int result = -1;
                var tournamentTmp = _unitOfWork.Tournament.GetById(tournament.Id);
                if (tournamentTmp != null)
                {
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
                    result = await _unitOfWork.Tournament.CreateAsync(tournament);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, tournament);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, tournament);
                    }
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
                var tournament = await _unitOfWork.Tournament.GetByIdAsync(id);
                if (tournament == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    var result = await _unitOfWork.Tournament.RemoveAsync(tournament);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, tournament);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, tournament);
                    }

                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> CreateTournament(TournamentCreateRequest tournamentCreateRequest)
        {
            try
            {
                if (tournamentCreateRequest.CreateAccount != null)
                {
                    var account = _unitOfWork.Account.GetById(tournamentCreateRequest.CreateAccount.Value);
                    if (account == null) { tournamentCreateRequest.CreateAccount = null; }
                }
                int result = -1;
                Tournament newTournament = new Tournament
                {
                    Id = tournamentCreateRequest.Id,
                    StartDate = tournamentCreateRequest.StartDate,
                    EndDate = tournamentCreateRequest.EndDate,  
                    Name = tournamentCreateRequest.Name,
                    Status = tournamentCreateRequest.Status,
                    Note = tournamentCreateRequest.Note,
                    Code = tournamentCreateRequest.Code,
                    CreateDate = DateTime.Now,
                    CreateAccount = tournamentCreateRequest.CreateAccount
                };


                result = await _unitOfWork.Tournament.CreateAsync(newTournament);
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

        public async Task<IBusinessResult> UpdateTournament(TournamentUpdateRequest tournamentUpdateRequest)
        {
            try
            {
                int result = -1;
                var tournament = _unitOfWork.Tournament.GetById(tournamentUpdateRequest.Id);

                if (tournament != null)
                {
                    _unitOfWork.Tournament.Context().Entry(tournament).CurrentValues.SetValues(tournamentUpdateRequest);
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
        public async Task<IBusinessResult> GetTournamentName()
        {
            var club = await _unitOfWork.Tournament.GetListTournamentName();
            if (club != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, club);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }

    }
}
