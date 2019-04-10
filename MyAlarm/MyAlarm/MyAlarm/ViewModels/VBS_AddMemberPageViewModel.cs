using Logic;
using MyAlarm.Domain;
using MyAlarm.EFStandard;
using MyAlarm.Helpers;
using MyAlarm.Model;
using MyAlarm.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlarm.ViewModels
{
    class VBS_AddMemberPageViewModel : BaseViewModel
    {
        private MemberLogic logic; 

        public VBS_AddMemberPageViewModel(InitParamVm initParamVm) : base(initParamVm)
        {
            logic = new MemberLogic(Helper.GetConnectionString());
        }

        #region BindProp
        #region NameMemberBindProp
        private string _NameMemberBindProp = "";
        public string NameMemberBindProp
        {
            get { return _NameMemberBindProp; }
            set { SetProperty(ref _NameMemberBindProp, value); }
        }
        #endregion

        #region GenderMemberBindProp
        private string _GenderMemberBindProp = "";
        public string GenderMemberBindProp
        {
            get { return _GenderMemberBindProp; }
            set { SetProperty(ref _GenderMemberBindProp, value); }
        }
        #endregion

        #region PhoneNumberMemberBindProp
        private string _PhoneNumberMemberBindProp = "";
        public string PhoneNumberMemberBindProp
        {
            get { return _PhoneNumberMemberBindProp; }
            set { SetProperty(ref _PhoneNumberMemberBindProp, value); }
        }
        #endregion

        #region EmailMemberBindProp
        private string _EmailMemberBindProp = "";
        public string EmailMemberBindProp
        {
            get { return _EmailMemberBindProp; }
            set { SetProperty(ref _EmailMemberBindProp, value); }
        }
        #endregion
        #endregion

        #region Command

        #region AddMemberCommand

        public DelegateCommand<object> AddMemberCommand { get; private set; }
        private bool CanAdd(object b)
        {
            if (IsNotBusyBindProp && string.IsNullOrWhiteSpace(NameMemberBindProp) == false && string.IsNullOrWhiteSpace(GenderMemberBindProp) == false
                && string.IsNullOrWhiteSpace(PhoneNumberMemberBindProp) == false && string.IsNullOrWhiteSpace(EmailMemberBindProp) == false)
            {
                return true;
            }
            return false;
        }
        private async void OnAddMember(object obj)
        {
            if (CanAdd(obj) == false)
            {
                return;
            }

            IsBusyBindProp = true;

            // Thuc hien cong viec tai day

            var member = new Member
            {
                Id = Guid.NewGuid().ToString(),
                Name = NameMemberBindProp,
                NumPhone = PhoneNumberMemberBindProp,
                Gender = GenderMemberBindProp,
                Email = EmailMemberBindProp,
                FkRole = "R03"
            };
            
            
            var createMember = await logic.CreateMember(member);
            
            
            IsBusyBindProp = false;
        }

        [Initialize]
        private void InitAddMemberCommand()
        {
            AddMemberCommand = new DelegateCommand<object>(OnAddMember);
            AddMemberCommand.ObservesCanExecute(() => IsNotBusyBindProp);
        }

        #endregion

        #region GoBackCommand

        public DelegateCommand<object> GoBackCommand { get; private set; }
        private async void OnGoBack(object obj)
        {
            if (IsBusyBindProp)
            {
                return;
            }

            IsBusyBindProp = true;

            // Thuc hien cong viec tai day
            await NavigationService.GoBackAsync();

            IsBusyBindProp = false;
        }

        [Initialize]
        private void InitGoBackCommand()
        {
            GoBackCommand = new DelegateCommand<object>(OnGoBack);
            GoBackCommand.ObservesCanExecute(() => IsNotBusyBindProp);
        }

        #endregion 

       


        #endregion

    }
}
