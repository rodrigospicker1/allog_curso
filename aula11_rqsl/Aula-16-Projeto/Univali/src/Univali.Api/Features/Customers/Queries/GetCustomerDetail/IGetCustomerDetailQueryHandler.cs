public interface IGetCustomerDetailQueryHanler
{
    Task<GetCustomerDetailDto?> Handle(GetCustomerDetailQuery request);
}