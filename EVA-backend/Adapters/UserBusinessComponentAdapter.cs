using EVA_backend.DataLayer;
using EVA_backend.DataModels;
using EVA_backend.Entities;
using EVA_backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EVA_backend.Adapters
{
    public class UserBusinessComponentAdapter
    {
        private UserRepository _uRepo;   
        public UserBusinessComponentAdapter()
        {
            _uRepo = new UserRepository();
        }

        public User MapToUser(UserModel dto)
        {
            return new User()
            {
                NmbrOfChildren = dto.NmbrOfChildren,
                Email = dto.Email,
                UserName = dto.Email,
                IsStudent = dto.IsStudent,
                Language = dto.Language,
                BirthDate = dto.BirthDate,
                Gender = dto.Gender,
                Difficulty = dto.Difficulty,
                SendNewsletter = dto.SendNewsletter
            };
        }

        public UserModel MapToUserModel(User entity)
        {
            if (entity != null)
            {
                return new UserModel()
                {
                    NmbrOfChildren = entity.NmbrOfChildren,
                    Email = entity.Email,
                    UserName = entity.Email,
                    IsStudent = entity.IsStudent,
                    Language = entity.Language,
                    BirthDate = entity.BirthDate,
                    Gender = entity.Gender,
                    Difficulty = entity.Difficulty,
                    SendNewsletter = entity.SendNewsletter
                };
            }
            else return new UserModel();
        }

        public int  InsertUser(UserModel dto)
        {
            //first map to user then insert the new entity into the db
          return _uRepo.InsertUser(MapToUser(dto));
        }

        public UserModel GetUserByEmail(string email)
        {
           return MapToUserModel(_uRepo.GetUserByEmail(email));
        }

        public void DeleteUser(UserModel dto)
        {
            _uRepo.DeleteUser(MapToUser(dto));
        }
    }
}