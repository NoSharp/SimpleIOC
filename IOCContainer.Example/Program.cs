namespace IOCContainer.Example
{
    class Program
    {
        static void Main(string[] args)
        {
  
            IocContainer.Instance.Set<ITest, Test>();
            IocContainer.Instance.Set<ITest2, Test2>("test2","test3");
            IocContainer.Instance.Get<ITest>().Print();
        }
    }
}