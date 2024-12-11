using Mapster;
using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using SWD.SportShirtShop.Services.RequetsModel.ShirtEdition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Service
{
    public class ShirtEditionSerivce : IShirtEditionSerivice
    {
        private IShirtEditionSerivice shirtEditionSerivice;
        private UnitOfWork _unitOfWork;
        public ShirtEditionSerivce(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IBusinessResult> GetAll()
        {
            var categories = await _unitOfWork.ShirtEdition.GetAllAsync();
            if (categories != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, categories);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var account = await _unitOfWork.ShirtEdition.GetByIdAsync(id);
            if (account == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, account);
            }
        }

        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var account = await _unitOfWork.ShirtEdition.GetByIdAsync(id);
                if (account == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    int result = -1;
                    account.Status = "Deleted";
                     result = await _unitOfWork.ShirtEdition.UpdateAsync(account);
                    if (result >0)
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

        public async Task<IBusinessResult> Create(ShirtEditionCreateRequest request)
        {
            try
            {
                int result = -1;
                //var userId = claim.FindFirst("id")?.Value;


                
                    var account = _unitOfWork.Account.GetById(request.CreateAccount.Value);
                    var tournament = _unitOfWork.Tournament.GetById(request.IdTournament.Value);
                    if (account == null) { request.CreateAccount = null; }
                    if (tournament == null) { request.IdTournament = null; }
                    //if (userId == null)
                    //{
                    //    return new BusinessResult(Const.ERROR_EXCEPTION, "Do not have idUser");
                    //}
                    //var product = C.Adapt<Product>();

                    ShirtEdition newClub = new ShirtEdition
                    {
                      
                        IdTournamentClub = request.IdTournament,
                        Status = request.Status,
                        Note = request.Note,
                        Code = request.Code,
                        CreateDate = DateTime.Now,
                        CreateAccount = request.CreateAccount
                    };


                    result = await _unitOfWork.ShirtEdition.CreateAsync(newClub);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, newClub);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, newClub);
                    }
                
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> Update(UpdateShirtEditionRequest request)
        {
            try
            {
                int result = -1;
                //var userId = claim.FindFirst("id")?.Value;
                //if (userId == null)
                //{
                //    return new BusinessResult(Const.ERROR_EXCEPTION, "Do not have idUser");
                //}
                var club = _unitOfWork.ShirtEdition.GetById(request.Id);


                var update = request.Adapt<ShirtEdition>();


                if (club != null)
                {
                    result = await _unitOfWork.ShirtEdition.UpdateAsync(update);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, club);
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

      
    }
}
