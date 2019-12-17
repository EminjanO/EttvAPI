using System;
using System.Collections.Generic;
using System.Linq;
using EttvAPI.Repos.Repositories;
using EttvAPI.Services.Communication;
using EttvAPI.Services.Interfaces;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Interfaces.Repositories;

namespace EttvAPI.Services
{
    public class ChannelProgramService : IChannelProgramService
    {
        private readonly UnitOfWork _unitOfWork;

        public ChannelProgramService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }
        public IEnumerable<ChannelProgram> List()
        {
            return _unitOfWork.channelProgramRepository.GetAll().Select(c =>
            {
                c.StartTime = DateTime.SpecifyKind(c.StartTime, DateTimeKind.Utc);
                c.EndTime = DateTime.SpecifyKind(c.EndTime, DateTimeKind.Utc);
                return c;
            });
        }

        public ChannelProgramResponce Save(ChannelProgram channelProgram)
        {
            try
            {
                _unitOfWork.channelProgramRepository.Add(channelProgram);
                _unitOfWork.Commit();

                return new ChannelProgramResponce(channelProgram);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ChannelProgramResponce($"An error occurred when saving the program: {ex.Message}");
            }
        }

        public ChannelProgramResponce Update(int id, ChannelProgram channelProgram)
        {
            var existingProgram = _unitOfWork.channelProgramRepository.GetById(id);

            if (existingProgram == null)
                return new ChannelProgramResponce("program not found.");

            existingProgram.StartTime = channelProgram.StartTime;
            existingProgram.EndTime = channelProgram.EndTime;

            try
            {
                _unitOfWork.channelProgramRepository.Update(existingProgram);
                _unitOfWork.Commit();

                return new ChannelProgramResponce(existingProgram);
            }
            catch (Exception ex)
            {
                //TODO some logging stuff here
                return new ChannelProgramResponce($"An error occurred when updating the Programs Scheduling Time: {ex.Message}");
            }
        }

        public ChannelProgramResponce Delete(int id)
        {
            var existingProgram = _unitOfWork.channelProgramRepository.GetById(id);

            if (existingProgram == null)
                return new ChannelProgramResponce("program not found.");

            try
            {
                _unitOfWork.channelProgramRepository.Delete(existingProgram);
                _unitOfWork.Commit();

                return new ChannelProgramResponce(existingProgram);
            }
            catch (Exception ex)
            {
                //TODO some logging stuff here
                return new ChannelProgramResponce($"An error occurred when deleting the program : {ex.Message}");
            }
        }
    }
}
