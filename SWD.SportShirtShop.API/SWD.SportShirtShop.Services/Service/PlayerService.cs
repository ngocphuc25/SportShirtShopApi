using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Common;
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
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly UnitOfWork _unitOfWork;
        public PlayerService(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

        public async Task<IBusinessResult> GetAll()
        {
            var player = await _unitOfWork.Player.GetAllAsync();
            if (player != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, player);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var player = await _unitOfWork.Player.GetByIdAsync(id);
            if (player == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, player);
            }
        }
        
        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var account = await _unitOfWork.Player.GetByIdAsync(id);
                if (account == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    var result = await _unitOfWork.Player.RemoveAsync(account);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, account);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, account);
                    }

                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> CreatePlayer(PlayerCreateRequest playerCreateRequest)
        {
            try
            {
                if (playerCreateRequest.CreateAccount != null)
                {
                    var account = _unitOfWork.Account.GetById(playerCreateRequest.CreateAccount.Value);
                    if (account == null) { playerCreateRequest.CreateAccount = null; }
                }
                if (playerCreateRequest.IdClub != null)
                {
                    var club = _unitOfWork.Club.GetById(playerCreateRequest.IdClub.Value);
                    if (club == null)
                        return  new BusinessResult(Const.FAIL_CREATE_CODE, "Không tìm thấy id club");
                }
                int result = -1;

                Player newPlayer = new Player
                {
                   
                    IdClub = playerCreateRequest.IdClub,
                    Name = playerCreateRequest.Name,
                    Dob = playerCreateRequest.Dob,
                    Note = playerCreateRequest.Note,
                    Code = playerCreateRequest.Code,
                    CreateDate = DateTime.Now,
                    CreateAccount = playerCreateRequest.CreateAccount
                };


                result = await _unitOfWork.Player.CreateAsync(newPlayer);
                if (result > 0)
                {
                    return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, newPlayer);
                }
                else
                {
                    return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, newPlayer);
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> UpdatePlayer(PlayerUpdateRequest playerUpdateRequets)
        {
            try
            {
                int result = -1;
                var player = _unitOfWork.Player.GetById(playerUpdateRequets.Id);
                if (player != null)
                {
                    if (playerUpdateRequets.IdClub != null)
                    {
                        var club = _unitOfWork.Club.GetById(playerUpdateRequets.IdClub.Value);
                        if (club == null)
                            return new BusinessResult(Const.FAIL_CREATE_CODE, "Không tìm thấy id club");
                    }
                    _unitOfWork.Player.Context().Entry(player).CurrentValues.SetValues(player);
                    result = await _unitOfWork.Player.UpdateAsync(player);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, player);
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

        public async Task<IBusinessResult> Save(Player player)
        {
            try
            {
                int result = -1;
                var accountTmp = _unitOfWork.Player.GetById(player.Id);
                if (accountTmp != null)
                {
                    result = await _unitOfWork.Player.UpdateAsync(player);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, player);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.Player.CreateAsync(player);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, player);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, player);
                    }
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }

        }

        public async Task<IBusinessResult> GetlistName()
        {
            var club = await _unitOfWork.Player.GetListPlayerName();
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
