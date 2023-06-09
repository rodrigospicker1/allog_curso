using AutoMapper;

public class CustomerProfiles : Profile
{
    public CustomerProfiles()
    {
        CreateMap<Entities.Customer, Models.CustomerDto>();
    }
}