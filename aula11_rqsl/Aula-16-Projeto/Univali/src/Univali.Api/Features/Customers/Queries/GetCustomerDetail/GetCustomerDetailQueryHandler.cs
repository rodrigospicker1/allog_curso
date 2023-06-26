public class GetCustomerDetailQueryHandler : IGetCustomerDetailQueryHanler
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerDetailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<GetCustomerDetailDto?> Handle(GetCustomerDetailQuery request)
    {
        var customerFromDatabase = 
    }
}