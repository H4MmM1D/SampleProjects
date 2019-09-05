namespace Service
{
    public interface IAppService
    {
        string AddUrl(string url);

        string VisitUrl(string token);
    }
}
