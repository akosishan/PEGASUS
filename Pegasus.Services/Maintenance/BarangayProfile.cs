﻿using Pegasus.Data;
using Pegasus.Models.Maintenance;
using System.Collections.Generic;
using Pegasus.Repository;
using System.Linq;
using Microsoft.VisualBasic;
using System;

namespace Pegasus.Services.Maintenance
{
    public class BarangayProfile : IBarangayProfile
    {
        private readonly IRepository<Barangay> _repoBarangay;
       
        public BarangayProfile(IRepository<Barangay> repoBarangay)
        {
            _repoBarangay = repoBarangay;
        }
        public void CreateBarangay(BarangayModel model)
        {
            _repoBarangay.AddAsync(new Barangay
            {
                BarangayName = model.BarangayName,
                BarangayAddress = model.BarangayAddress,
                BarangayLocation = model.BarangayLocation,
                BarangayLogoPath = model.BarangayLogoPath,
                BarangayQrCode = model.BarangayQrCode,
                DateCreated = DateTime.Now
            });

            
        }

        public BarangayModel GetBarangay(int id)
        {
            return _repoBarangay.GetAll().Select(x => new BarangayModel
            {
                Id = x.Id,
                BarangayAddress = x.BarangayAddress,
                BarangayLocation = x.BarangayLocation,
                BarangayLogoPath = x.BarangayLogoPath,
                BarangayName = x.BarangayName,
                BarangayQrCode = x.BarangayQrCode,
                DateCreated = x.DateCreated
            }).FirstOrDefault(x=>x.Id==id);
        }

        public BarangayModel GetBarangay(string name)
        {
            return _repoBarangay.GetAll().Select(x => new BarangayModel
            {
                Id = x.Id,
                BarangayAddress = x.BarangayAddress,
                BarangayLocation = x.BarangayLocation,
                BarangayLogoPath = x.BarangayLogoPath,
                BarangayName = x.BarangayName,
                BarangayQrCode = x.BarangayQrCode,
                DateCreated = x.DateCreated
            }).FirstOrDefault(x => x.BarangayName == name);
        }

        public List<BarangayModel> GetBarangays()
        {
            return _repoBarangay.GetAll().Select(x=> new BarangayModel { 
                Id=x.Id,
                 BarangayAddress=x.BarangayAddress,
                  BarangayLocation=x.BarangayLocation,
                   BarangayLogoPath =x.BarangayLogoPath,
                    BarangayName=x.BarangayName,
                     BarangayQrCode=x.BarangayQrCode,
                      DateCreated=x.DateCreated
            }).ToList();
        }

        public void RemoveBarangay(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBarangay(BarangayModel model)
        {
            _repoBarangay.UpdateAsync(new Barangay
            {
                Id=model.Id,
                BarangayName = model.BarangayName,
                BarangayAddress = model.BarangayAddress,
                BarangayLocation = model.BarangayLocation,
                BarangayLogoPath = model.BarangayLogoPath,
                BarangayQrCode = model.BarangayQrCode,
                DateCreated = DateAndTime.Now
            });
        }
    }
}
