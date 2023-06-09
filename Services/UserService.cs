﻿using Entity;
using Repositories;
using System.Runtime.InteropServices;
using System.Text.Json;
using Services;

namespace Services
{
    public class UserService:IUserService

    {
        IUserRepository _userRepository;
        IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;

        }

        public IEnumerable<string> GetAllUsers()
            
        {
            return new string[] { "value1", "value2" };
            //UserRepository.Get();

        }

        // GET api/<UserController>/5

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
           

        }

        // POST api/<UserController>

        public async Task<User> CreatUser(User user)
        {

            int password = _passwordService.CheckStrengthPassword(user.Password);
            if (password <= 2)
            { return null; }
          
             return await _userRepository.CreatUser(user);
            

        }

        public async  Task<User> Login(User detailsofuser)
        {
            return await _userRepository.Login(detailsofuser);
            


        }


        // PUT api/<UserController>/5

        public async Task UpdateUserById(int id, User userToUpdate)
        {
            await _userRepository.UpdateUserById(id, userToUpdate);
           

        }

        // DELETE api/<UserController>/
        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
    }

    
}