namespace AopSample
{
    internal interface IService
    {
        void Do();

        string DoAndReturn();

        void Abort();

        void Close();
    }
}
