namespace CustomerApi.Data
{
    interface IDbInitializer
    {
        void Initialize(CustomerApiContext context);
    }
}
