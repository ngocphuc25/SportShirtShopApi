﻿using Microsoft.AspNetCore.Mvc;
using SWD.SportShirtShop.Services.Base;
using SWD.SportShirtShop.Services.Interface;
using SWD.SportShirtShop.Services.RequetsModel.Order;
using SWD.SportShirtShop.Services.RequetsModel.Shirt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWD.SportShirtShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/<OrderController>
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

            [HttpGet]
        public async Task<IBusinessResult> GetAll()
        {
            return await _orderService.GetAll();
        }

        // GET api/<ShirtEditionController>/5
        [HttpGet("{id}")]
        public async Task<IBusinessResult> GetByID(int id)
        {
            return await _orderService.GetById(id);
        }

        // POST api/<ShirtEditionController>
        [HttpPost]
        public async Task<IBusinessResult> Post([FromBody] CreateOrderRequest value)
        {
            return await _orderService.CreateOrder(value);
        }

        // PUT api/<ShirtController>/5
        //[HttpPut]
        //public async Task<IBusinessResult> Put([FromBody] ShirtUpdateRequest value)
        //{
        //    return await _shirt.Update(value);
        //}

        //// DELETE api/<ShirtController>/5
        //[HttpDelete("{id}")]
        //public async Task<IBusinessResult> Delete(int id)
        //{
        //    return await _orderService.DeleteById(id);
        //}

        //// PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
