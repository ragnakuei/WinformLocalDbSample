namespace WinformLocalDbSample
{
    public class TestService
    {
        private readonly TestRepository _testRepository;

        public TestService(TestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public TestDTO[] Get()
        {
            return _testRepository.Get();
        }

        public void Add(TestDTO testDto)
        {
            _testRepository.Add(testDto);
        }
    }
}
