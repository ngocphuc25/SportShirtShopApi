using Azure.Core;
using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Club;
using System.Security.Claims;

namespace SWD.SportShirtShop.Services.Service
{
    public class ClubService :IClubService
    {
        private readonly UnitOfWork _unitOfWork;
        public ClubService(UnitOfWork unitOfWork) {_unitOfWork = unitOfWork;}

        public async Task<IBusinessResult> GetAll()
        {
            var club = await _unitOfWork.Club.GetAllAsync();
            if (club != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, club);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }
        public async Task<IBusinessResult> GetClubName()
        {
            var club =await _unitOfWork.Club.GetListClubName();
            if (club != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, club);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var club = await _unitOfWork.Club.GetByIdAsync(id);
            if (club == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, club);
            }
        }

        public async Task<IBusinessResult> DeleteById(int id)
        {
            try
            {
                var club = await _unitOfWork.Club.GetByIdAsync(id);
                if (club == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    var result = await _unitOfWork.Club.RemoveAsync(club);
                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, club);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, club);
                    }

                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.ToString());
            }
        }

        public async Task<IBusinessResult> CreateClub(ClubCreateRequest clubCreateRequest)
        {
            try
            {
                int result = -1;
                if (clubCreateRequest.CreateAccount != null)
                {
                    var account = _unitOfWork.Account.GetById(clubCreateRequest.CreateAccount.Value);
                    if (account == null) { clubCreateRequest.CreateAccount = null; }
                }



                Club newClub = new Club
                {

                    Name = clubCreateRequest.Name,
                    Logo = clubCreateRequest.Logo,
                    Status = clubCreateRequest.Status,
                    Note = clubCreateRequest.Note,
                    Code = clubCreateRequest.Code,
                    CreateDate = DateTime.Now,
                    CreateAccount = clubCreateRequest.CreateAccount
                };

                
                result = await _unitOfWork.Club.CreateAsync(newClub);
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

        public async Task<IBusinessResult> UpdateClub(ClubUpdateRequets clubUpdateRequest)
        {
            try
            {
                int result = -1;
                var club = _unitOfWork.Club.GetById(clubUpdateRequest.Id);

                if (club != null)
                {
                    _unitOfWork.Club.Context().Entry(club).CurrentValues.SetValues(clubUpdateRequest);
                    result = await _unitOfWork.Club.UpdateAsync(club);
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

        public async Task<IBusinessResult> Save(Club club)
        {
            try
            {
                int result = -1;
                var clubTmp = _unitOfWork.Club.GetById(club.Id);

                if (clubTmp != null)
                {


                    result = await _unitOfWork.Club.UpdateAsync(club);
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
                    result = await _unitOfWork.Club.CreateAsync(club);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, club);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, club);
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
