using Mapster;
using SWD.SportShirtShop.Common;
using SWD.SportShirtShop.Repo;
using SWD.SportShirtShop.Repo.Entities;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Shirt;
using SWD.SportShirtShop.Services.RequetsModel.ShirtEdition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SportShirtShop.Services.Service
{
    public class ShirtService :IShirtService
    {
         private UnitOfWork _unitOfWork;
        public ShirtService(UnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }
        public async Task<IBusinessResult> GetAll()
        {
            var categories = await _unitOfWork.Shirt.GetAllAsync();
            if (categories != null)
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, categories);
            }
            else
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
            }
        }
        public async Task<IBusinessResult> GetAllShirtsWithImagesAsync()
        {
            var categories = await _unitOfWork.Shirt.GetAllShirtsWithImagesAsync();
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
            var account = await _unitOfWork.Shirt.GetByIdAsync(id);
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
                var account = await _unitOfWork.Shirt.GetByIdAsync(id);
                if (account == null)
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG);
                }
                else
                {
                    int result = -1;
               //     account.Status = "Deleted";
                    result = await _unitOfWork.Shirt.UpdateAsync(account);
                    if (result > 0)
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

        public async Task<IBusinessResult> Create(ShirtCreateRequest request)
        {
            try
            {
                int result = -1;
                //var userId = claim.FindFirst("id")?.Value;

                var idPlayer= _unitOfWork.PlayerInTournamentClub.GetById(request.IdPlayerinTournamentClub.Value);
                var idAccount = _unitOfWork.Account.GetById(request.CreateAccount.Value);
                var idShirtEdition = _unitOfWork.ShirtEdition.GetById(request.IdShirtEdition.Value);
                //var playerIntournament = _unitOfWork.Tournament.GetById(request.IdPlayerinTournamentClub.Value);
                if (idShirtEdition == null) { request.IdShirtEdition = null; }
                if (idAccount == null) { request.CreateAccount = null; }
                if (idPlayer == null) { request.IdPlayerinTournamentClub = null; }
                
           //     if (tournament == null) { request.IdTournament = null; }
                //if (userId == null)
                //{
                //    return new BusinessResult(Const.ERROR_EXCEPTION, "Do not have idUser");
                //}
                //var product = C.Adapt<Product>();

                Shirt newClub = new Shirt
                {
                    IdPlayerinTournamentClub = request.IdPlayerinTournamentClub,
                    IdShirtEdition = request.IdShirtEdition,
                   Description = request.Description,
                   Code = request.Code,
                   Name = request.Name,
                   QuantityStock = request.QuantityStock,
                   Price = request.Price,
                    CreateDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreateAccount = request.CreateAccount,
                    Status = request.Status,
                    TotalSold=0,
                    SalePrice= request.SalePrice,
                    
                };
                foreach (var url in request.links)
                {
                    var image = new Image
                    {
                       Link=url.link
                                     // Liên kết với Shirt
                    };
                    newClub.Images.Add(image);
                }

                result = await _unitOfWork.Shirt.CreateAsync(newClub);
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

        public async Task<IBusinessResult> Update(ShirtUpdateRequest request)
        {
            try
            {
                int result = -1;
                //var userId = claim.FindFirst("id")?.Value;
                //if (userId == null)
                //{
                //    return new BusinessResult(Const.ERROR_EXCEPTION, "Do not have idUser");
                //}
                var club = _unitOfWork.Shirt.GetById(request.Id);


                var update = request.Adapt<Shirt>();


                if (club != null)
                {
                    result = await _unitOfWork.Shirt.UpdateAsync(update);
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
