using System;
using System.Collections.Generic;
using EttvAPI.Data.Models;
using EttvAPI.Repos.Interfaces.Repositories;
using EttvAPI.Repos.Repositories;
using EttvAPI.Services.Communication;
using EttvAPI.Services.Interfaces;

namespace EttvAPI.Services
{
    public class VideoContentService : IVideoContentService
    {
        private readonly UnitOfWork _unitOfWork;

        public VideoContentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }
        public IEnumerable<VideoContent> List()
        {
            return _unitOfWork.videoContentRepository.GetAll();
        }

        public VideoContentResponce Save(VideoContent videoContent)
        {
            try
            {
                _unitOfWork.videoContentRepository.Add(videoContent);
                _unitOfWork.Commit();
                return new VideoContentResponce(videoContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new VideoContentResponce($"An error occurred when saving the videoContent: {ex.Message}");
            }
        }

        public VideoContentResponce Update(string videoId, VideoContent videoContent)
        {
            var existingVideo = _unitOfWork.videoContentRepository.GetByStringId(videoId);

            if(existingVideo == null)
                return new VideoContentResponce("Video Content not found.");

            existingVideo.Tag = videoContent.Tag;

            try
            {
                _unitOfWork.videoContentRepository.Update(existingVideo);
                _unitOfWork.Commit();
                
                return new VideoContentResponce(existingVideo);
            }
            catch (Exception ex)
            {
                //TODO some logging stuff here
                return new VideoContentResponce($"An error occurred when updating the VideoContents Tag: {ex.Message}");
            }
        }

        public VideoContentResponce Delete(string videoId)
        {
            var existVideo = _unitOfWork.videoContentRepository.GetByStringId(videoId);

            if(existVideo == null)
                return new VideoContentResponce("Video not found.");

            try
            {
                _unitOfWork.videoContentRepository.Delete(existVideo);
                _unitOfWork.Commit();

                return new VideoContentResponce(existVideo);
            }
            catch (Exception ex)
            {
                //TODO some logging stuff here
                return new VideoContentResponce($"An error occurred when Deleting the video content: {ex.Message}");
            }
        }
    }
}
