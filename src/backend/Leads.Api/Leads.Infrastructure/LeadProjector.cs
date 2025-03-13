//// Leads.Infrastructure/ReadModel/LeadProjector.cs
//using Leads.Domain.Events;

//namespace Leads.Infrastructure.ReadModel
//{
//    public class LeadProjector
//    {
//        private readonly IInMemoryReadModelRepository _repository;

//        public LeadProjector(IInMemoryReadModelRepository repository)
//        {
//            _repository = repository;
//        }

//        /// <summary>
//        /// Processa um evento e atualiza o read model em memória.
//        /// </summary>
//        /// <param name="evt">O evento de domínio a ser processado</param>
//        public Task ProjectAsync(object evt)
//        {
//            switch (evt)
//            {
//                case LeadCreated e:
//                    var newLead = new LeadReadModel
//                    {
//                        LeadId = e.LeadId,
//                        ContactFirstName = e.ContactFirstName,
//                        ContactLastName = e.ContactLastName,
//                        DateCreated = e.DateCreated,
//                        Suburb = e.Suburb,
//                        Category = e.Category,
//                        Description = e.Description,
//                        Price = e.Price,
//                        ContactPhoneNumber = e.ContactPhoneNumber,
//                        ContactEmail = e.ContactEmail,
//                        Status = "Invited"
//                    };
//                    _repository.Add(newLead);
//                    break;

//                case LeadAccepted e:
//                    var leadAccepted = _repository.GetAll().FirstOrDefault(l => l.LeadId == e.LeadId);
//                    if (leadAccepted != null)
//                    {
//                        leadAccepted.Price = e.FinalPrice;
//                        leadAccepted.Status = "Accepted";
//                        _repository.Update(leadAccepted);
//                    }
//                    break;

//                case LeadDeclined e:
//                    var leadDeclined = _repository.GetAll().FirstOrDefault(l => l.LeadId == e.LeadId);
//                    if (leadDeclined != null)
//                    {
//                        leadDeclined.Status = "Declined";
//                        _repository.Update(leadDeclined);
//                    }
//                    break;
//            }
//            return Task.CompletedTask;
//        }
//    }
//}
