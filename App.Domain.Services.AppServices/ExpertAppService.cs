using App.Domain.Core.Contract.AppService;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.DTOs.ExpertDto;
using App.Domain.Core.DTOs.ServiceDto;
using App.Domain.Core.Entities.Services;
using App.Domain.Core.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _expertService;
        private readonly IReviewAppService _reviewAppService;
        private readonly IServiceOfferingAppService _serviceOfferingAppService;
        private readonly IServiceRequestAppService _servicerequestAppService;
        private readonly IUtilityService _utilityService;

        public ExpertAppService(IExpertService expertService,
                                IUtilityService utilityService,
                                IReviewAppService reviewAppService,
                                IServiceOfferingAppService serviceOfferingAppService,
                                IServiceRequestAppService serviceRequestAppService)
        {
            _expertService = expertService;
            _utilityService = utilityService;
            _reviewAppService = reviewAppService;
            _serviceOfferingAppService = serviceOfferingAppService;
            _servicerequestAppService = serviceRequestAppService;
        }

        public async Task ChangeStatus(int id, CancellationToken cancellationToken)
        {
            await _expertService.ChangeStatus(id, cancellationToken);
        }

        public async Task Create(CreateExpertDto createExpertDto, CancellationToken cancellationToken)
        {
            await _expertService.Add(createExpertDto,cancellationToken);
        }

        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _expertService.Delete(id,cancellationToken);
        }

        public async Task<List<Expert>> GetAll(CancellationToken cancellationToken)
        {
            return await _expertService.GetAll(cancellationToken);
        }

        public async Task<Expert> GetById(int id, CancellationToken cancellationToken)
        {
            return await _expertService.Get(id,cancellationToken);
        }

        public async Task<Expert> GetExpertByUserId(int userId, CancellationToken cancellationToken)
        {
            var Experts = await _expertService.GetAll(default);
            return (Expert)Experts.Where(e => e.AppUserId == userId).FirstOrDefault();
        }

        public async Task<Expert> GetExpertInfo(int id, CancellationToken cancellationToken)
        {
            return await _expertService.GetExpertInfo(id,cancellationToken);
        }

        public async Task<List<Review>> GetExpertReview(int Id, CancellationToken cancellationToken)
        {
            var reviews = await _reviewAppService.GetAll(default);
            return reviews.Where(x => x.ServiceOffering.ExpertId == Id).ToList();
        }

        public async Task<List<GetServiceDto>> GetExpertSkills(int userId, CancellationToken cancellationToken)
        {
            var expert = await GetExpertByUserId(userId,default);
            var services = expert.Services;
            var skills  = new List<GetServiceDto>();
            foreach (var service in services)
            {
                skills.Add(new GetServiceDto
                {
                    Id = service.Id,
                    Name = service.Title,
                    Price = (int)service.Price
                });
            }
            return skills;
        }

        public async Task<List<ServiceOffering>> GetServiceOfferings(int Id, CancellationToken cancellationToken)
        {
            var expert = await GetExpertByUserId(Id,cancellationToken);
            var model = await _serviceOfferingAppService.GetAll(cancellationToken);
            return model.Where(x => x.ExpertId == Id).ToList();
        }

        public async Task<List<ServiceRequest>> GetServiceRequests(int Id, CancellationToken cancellationToken)
        {
            var skills = await GetExpertSkills(Id,cancellationToken);
            var requests = await _servicerequestAppService.GetAll(cancellationToken);
            var output = new List<ServiceRequest>();
            foreach (var request in requests)
            {
                foreach (var skill in skills)
                {
                    if (request.Service.Id == skill.Id)
                    {
                        output.Add(request);
                    }
                }
            }
            return output;
        }

        public async Task RemoveSkill(int Id, Service service, CancellationToken cancellationToken)
        {
            await _expertService.RemoveSkill(Id,service,cancellationToken);
        }

        public async Task Update(UpdateExpertDto updateExpertDto, CancellationToken cancellationToken,IFormFile Image)
        {
            var imagePath = await _utilityService.UploadImage(Image);
            updateExpertDto.ImagePath = imagePath;
            await _expertService.Update(updateExpertDto,cancellationToken);
        }

        public async Task UpdateSkills(int Id, Service service, CancellationToken cancellationToken)
        {
            await _expertService.UpdateSkills(Id,service,cancellationToken);
        }
    }
}
