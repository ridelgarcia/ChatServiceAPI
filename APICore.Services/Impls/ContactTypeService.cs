using APICore.Common.DTO.Response;
using APICore.Data.Model;
using APICore.Data.UoW;
using APICore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore.Services.Impls
{
    public class ContactTypeService : IContactTypeService
    {
        private IUnitOfWork _uow;

        public ContactTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<GetAllContactTypeResponse> GetAllContactTypes()
        {
            List<ContactType> ctList = _uow.ContactTypeRepository.GetAll().ToList<ContactType>();
            var response = new GetAllContactTypeResponse();
            response.ContactTypeList = new List<ContactTypeResponse>();
            foreach (ContactType ct in ctList)
            {
                var ctr = new ContactTypeResponse();
                ctr.Id = ct.Id;
                ctr.ContactTypeName = ct.Contacttypename;

                response.ContactTypeList.Add(ctr);
            }
            return await Task.FromResult(response);
        }
    }
}