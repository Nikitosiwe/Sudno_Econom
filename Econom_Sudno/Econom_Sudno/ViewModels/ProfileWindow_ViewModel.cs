using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

using Econom_Sudno.Models;
using Econom_Sudno.Context;

namespace Econom_Sudno.ViewModels
{
    class ProfileWindow_ViewModel 
    {
        private User profileOfUser;
        private ProfileWindow profileWindow;
        private bool createUser;

        public ProfileWindow_ViewModel(User u,ProfileWindow w, bool CU)
        {
            profileOfUser = u;
            profileWindow = w;
            createUser = CU;
            if (CU) 
            {
                profileWindow.ChangeUser_Panel.Visibility = System.Windows.Visibility.Collapsed;
                profileWindow.Registration_Panel.Visibility = System.Windows.Visibility.Visible;
            }
                
        }
        public ProfileWindow_ViewModel(UserApplication u, ProfileWindow w)
        {
            if (u==null) return;
            profileOfUser = new User {Name=u.Name,DocNumber=u.DocNumber};
            profileWindow = w;
            ((System.Windows.Controls.StackPanel)profileWindow.Box_Pass.Parent).Visibility = System.Windows.Visibility.Collapsed;
            ((System.Windows.Controls.StackPanel)profileWindow.Box_PassReplay.Parent).Visibility = System.Windows.Visibility.Collapsed;
            profileWindow.Box_Name.IsEnabled = false;
            profileWindow.Box_DocNumber.IsEnabled = false;
            profileWindow.ChangeButton.Visibility = System.Windows.Visibility.Collapsed;
            profileWindow.Height = 150;
        }

        private RelayCommand saveChangesOfProfile;
        public RelayCommand SaveChangesOfProfile
        {
            get
            {
                return saveChangesOfProfile ??
                    (saveChangesOfProfile = new RelayCommand(obj =>
                    {
                        if (!createUser) 
                        {
                            if (profileWindow.Box_Pass.Password != profileWindow.Box_PassReplay.Password) 
                                PrintMessage(System.Windows.Media.Brushes.Red,"Пароли не совпадают");
                            else
                            {
                                UserApplication u = new UserApplication
                                {
                                    Name = profileWindow.Box_Name.Text,
                                    Pass = profileWindow.Box_Pass.Password,
                                    DocNumber = profileWindow.Box_DocNumber.Text
                                };
                                if(CheckUserApp(u))
                                    ChangeUserData();
                            }
                        }
                        else
                        {
                            if (profileWindow.Box_Pass.Password != profileWindow.Box_PassReplay.Password)
                                PrintMessage(System.Windows.Media.Brushes.Red, "Пароли не совпадают");
                            else
                            {
                                if (profileWindow.Box_Pass.Password == "" && profileWindow.Box_PassReplay.Password == "")
                                {
                                    PrintMessage(System.Windows.Media.Brushes.Red, "Введите пароль");
                                }
                                else 
                                {
                                    UserApplication u = new UserApplication
                                    { 
                                        Name = profileWindow.Box_Name.Text,
                                        Pass= profileWindow.Box_Pass.Password,
                                        DocNumber = "\"" + profileWindow.Box_DocNumber.Text + "\""
                                    };
                                    if (CheckUserApp(u)) 
                                    { 
                                        ((MainWindow_ViewModel)profileWindow.Owner.DataContext).AddUserApplication(u);
                                        PrintMessage(System.Windows.Media.Brushes.Green, "Заявка на регистрацию подана");
                                    }
                                }
                            }
                        }
                    }));
            }
        }
        private void PrintMessage(System.Windows.Media.Brush brush,string str)
        {
            profileWindow.Message.Text = str;
            profileWindow.Message.Foreground = brush;
            profileWindow.Message.Visibility = System.Windows.Visibility.Visible;
        }
        public bool CheckUserApp(UserApplication user)
        {
            if (user.Name == "") { PrintMessage(System.Windows.Media.Brushes.Red, "Введите имя пользователя"); return false; }
            if (user.DocNumber == "") { PrintMessage(System.Windows.Media.Brushes.Red, "Введите документ пользователя"); return false; }
            using (UserContext db = new UserContext())
            {
                foreach (User u in db.Users)
                {
                    if (u.Name == user.Name) { PrintMessage(System.Windows.Media.Brushes.Red, "Пользователь с таким именем уже есть"); return false; }
                    if (u.DocNumber == user.DocNumber) { PrintMessage(System.Windows.Media.Brushes.Red, "Пользователь с таким документом уже есть"); return false; }
                    if (u.Pass == user.Pass) { PrintMessage(System.Windows.Media.Brushes.Red, "Пользователь с таким паролем уже есть"); return false; }
                }
            }
            return true;
        }

        public void ChangeUserData()
        {
            using (UserContext db = new UserContext())
            {
                foreach (User u in db.Users)
                {
                    if (u.Id == profileOfUser.Id)
                    {
                        if (profileWindow.Box_Pass.Password == "" && profileWindow.Box_PassReplay.Password == "")
                        {
                            u.Name = profileWindow.Box_Name.Text;
                            u.DocNumber = profileWindow.Box_DocNumber.Text;
                        }
                        else
                        {
                            u.Name = profileWindow.Box_Name.Text;
                            u.DocNumber = profileWindow.Box_DocNumber.Text;
                            u.Pass = profileWindow.Box_Pass.Password;
                        }
                        break;
                    }
                }
                db.SaveChanges();
                PrintMessage(System.Windows.Media.Brushes.Green, "Данные профиля изменены");
            }
        }


        public User ProfileOfUser
        {
            get { return profileOfUser; }
            set { profileOfUser = value; }
        }

    }
}
