using AutoMapper;
using ExampleWebApi.Models;
using ExampleWebApi.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ExampleWebApi.Controllers
{
    public class UserController : ApiController
    {
        private BookingContext context;

        public UserController()
        {
            context = new BookingContext();
        }


        [HttpGet]
        public IEnumerable<UserDTO> GetAll()
        {
            var users = context.User;

            var userDTO = Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);

            return userDTO;

        }


        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            var user = context.User.Find(id);

            if (user == null)
                NotFound();

            return Ok(Mapper.Map<User, UserDTO>(user));
        }

        [HttpPost]
        public IHttpActionResult Create(UserDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = Mapper.Map<UserDTO, User>(dto);

            context.User.Add(user);
            context.SaveChanges();

            dto.Id = user.Id;

            return Created(new Uri($"{Request.RequestUri}/{user.Id}"), dto);
        }
    }
}
