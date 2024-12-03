using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD.SportShirtShop.Services.RequetsModel.Club;

namespace SWD.SportShirtShop.Services.Service
{
    public class ClubService :IClubService
    {
        private readonly IClubService clubService;
        private readonly UnitOfWork _unitOfWork;

        public async Task<IBusinessResult> GetAll()
        {
            var categories = await _unitOfWork.Account.GetAllAsync();
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
            var account = await _unitOfWork.Account.GetByIdAsync(id);
            if (account == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, account);
            }
        }

        public async Task<IBusinessResult> Save(ClubCreateRequest accountCustomer)
        {
            try
            {
                int result = -1;
                var accountTmp = _unitOfWork.Account.GetById(accountCustomer.Id);
                if (accountTmp != null)
                {
                    result = await _unitOfWork.Account.UpdateAsync(accountCustomer);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, accountCustomer);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG);
                    }
                }
                else
                {
                    result = await _unitOfWork.Account.CreateAsync(accountCustomer);
                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, accountCustomer);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_CREATE_CODE, Const.FAIL_CREATE_MSG, accountCustomer);
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
                var account = await _unitOfWork.Account.GetByIdAsync(id);
                if (account == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    var result = await _unitOfWork.Account.RemoveAsync(account);
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
    }
}
