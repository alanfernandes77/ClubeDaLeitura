namespace ClubeDaLeitura.ConsoleApp.Services
{
    internal class ServiceManager
    {
        private readonly FriendService _friendService;
        private readonly BoxService _boxService;
        private readonly MagazineService _magazineService;
        private readonly LoanService _loanService;
        private readonly ReservationService _reservationService;
        private readonly CategoryService _categoryService;

        public ServiceManager()
        {
            _friendService = new FriendService();
            _boxService = new BoxService();
            _magazineService = new MagazineService();
            _loanService = new LoanService();
            _reservationService = new ReservationService();
            _categoryService = new CategoryService();
        }

        public FriendService GetFriendService() => _friendService;
        public BoxService GetBoxService() => _boxService;
        public MagazineService GetMagazineService() => _magazineService;

        public LoanService GetLoanService() => _loanService;

        public ReservationService GetReservationService() => _reservationService;

        public CategoryService GetCategoryService() => _categoryService;
    }
}