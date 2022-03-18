namespace ClubeDaLeitura.ConsoleApp.Services
{
    internal class ServiceManager
    {
        private readonly FriendService _friendService;
        private readonly BoxService _boxService;
        private readonly MagazineService _magazineService;
        private readonly LoanService _loanService;

        public ServiceManager()
        {
            _friendService = new FriendService();
            _boxService = new BoxService();
            _magazineService = new MagazineService();
            _loanService = new LoanService();
        }

        public FriendService GetFriendService() => _friendService;
        public BoxService GetBoxService() => _boxService;
        public MagazineService GetMagazineService() => _magazineService;

        public LoanService GetLoanService() => _loanService;
    }
}