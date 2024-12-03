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
        private readonly IClubService _clubService;
        private readonly UnitOfWork _unitOfWork;

        public async Task<IBusinessResult> GetAll()
        {
            var categories = await _unitOfWork.Club.GetAllAsync();
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
            var account = await _unitOfWork.Club.GetByIdAsync(id);
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
                var account = await _unitOfWork.Club.GetByIdAsync(id);
                if (account == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    var result = await _unitOfWork.Club.RemoveAsync(account);
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

        public async Task<IBusinessResult> Create(ClubCreateRequest clubCreateRequest, ClaimsPrincipal claim)
        {
            try
            {
                int result = -1;
                var userId = claim.FindFirst("id")?.Value;
                if (userId == null)
                {
                    return new BusinessResult(Const.ERROR_EXCEPTION, "Do not have idUser");
                }
                //var product = C.Adapt<Product>();

                Club newClub = new Club
                {
                    Id = clubCreateRequest.Id,
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

        public async Task<IBusinessResult> Update(ClubUpdateRequets clubUpdateRequets, ClaimsPrincipal claim)
        {
            try
            {
                int result = -1;
                var userId = claim.FindFirst("id")?.Value;
                if (userId == null)
                {
                    return new BusinessResult(Const.ERROR_EXCEPTION, "Do not have idUser");
                }
                var club = _unitOfWork.Club.GetById(clubUpdateRequets.Id);





                if (club != null)
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
                var accountTmp = _unitOfWork.Club.GetById(club.Id);

                if (accountTmp != null)
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
