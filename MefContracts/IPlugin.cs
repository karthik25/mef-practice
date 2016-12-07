namespace MefContracts
{
    public interface IPlugin
    {
        void PrePageRequest();
        void OnPageRequest();
        void PreViewRender();
        void OnActionInit();
    }
}
