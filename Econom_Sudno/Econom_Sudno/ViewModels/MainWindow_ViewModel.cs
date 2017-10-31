using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Controls;

using Econom_Sudno.Models;
using Econom_Sudno.Context;
using Econom_Sudno.HelpClasses;

namespace Econom_Sudno.ViewModels
{
    class MainWindow_ViewModel : INotifyPropertyChanged
    {
        private MainWindow view_MainWindow;
        private ObservableCollection<User> allUsers { get; set; }
        private User selectedUser { get; set; }
        public ObservableCollection<User> AllUsers 
        {
            get { return allUsers; }
            set { allUsers = value; OnPropertyChanged(); }
        }
        public User SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChanged(); }
        }
        private ObservableCollection<UserApplication> allUsersApplications { get; set; }
        private UserApplication selectedUserApplication { get; set; }
        public ObservableCollection<UserApplication> AllUsersApplications
        {
            get { return allUsersApplications; }
            set { allUsersApplications = value; OnPropertyChanged(); }
        }
        public UserApplication SelectedUserApplication
        {
            get { return selectedUserApplication; }
            set { selectedUserApplication = value; OnPropertyChanged(); }
        }

        private User currentUser;
        public User CurrentUser
        {
            get 
            {
                    if (currentUser == null) return currentUser;
                    if (currentUser.Id==1) 
                    {
                        view_MainWindow.UsersTab.Visibility = System.Windows.Visibility.Visible;
                    }
                    else
                    {
                        view_MainWindow.UsersTab.Visibility = System.Windows.Visibility.Collapsed;
                        view_MainWindow.Tabs.SelectedIndex = 0;
                    }
                    return currentUser; 
            }
            set
            {
                currentUser = value;
                OnPropertyChanged();
            }
        }

        private ShipTemplate currentShipTemplate { get; set; } 
        public ShipTemplate CurrentShipTemplate
        {
            get { return currentShipTemplate; }
            set
            {
                currentShipTemplate = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ShipTemplate> allShipTemplates { get; set; }
        public ObservableCollection<ShipTemplate> AllShipTemplates
        {
            get { return allShipTemplates; }
            set { allShipTemplates = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Rout> selectedRout_list { get; set; }
        public ObservableCollection<Rout> SelectedRout_list
        {
            get { return selectedRout_list; }
            set { selectedRout_list = value;OnPropertyChanged(); }
        }


   
        public MainWindow_ViewModel(MainWindow w)
        {
            view_MainWindow = w;
            using (UserContext db = new UserContext())
            {
                if (db.Users.Count() == 0)
                {
                    User user1 = new User { Name = "admin", Pass = "admin" };
                    db.Users.Add(user1);
                    db.SaveChanges();
                }
                //MessageBox.Show("kykykyk1");
                AllUsers_Update();
                //MessageBox.Show("kykykyk2");
                AllUsersApplications_Update();
                //MessageBox.Show("kykykyk3");
                AllShipTemplates_Update();

                CurrentShipTemplate = new ShipTemplate();
                SetBindings bindings = new SetBindings();
                bindings.SetBindingForCurrentShipTemplate(view_MainWindow, CurrentShipTemplate);
                bindings.SetBindingForAllShipTemplates(view_MainWindow, this);
            }
            
        }
        public void AllUsers_Update()
        {
            //MessageBox.Show("kykykyk11");
            using (UserContext db = new UserContext())
            {
                //MessageBox.Show("kykykyk12");
                AllUsers = new ObservableCollection<User>();
                AllUsers.Clear();
                foreach (User u in db.Users)
                {
                    //MessageBox.Show("kykykyk13");
                    if (currentUser != null)
                        if (currentUser.Id == u.Id)
                            continue;
                    AllUsers.Add(u);
                }
            }
        }

        public void AllUsersApplications_Update()
        {
            try
            {
                //MessageBox.Show("kykykyk21");
                using (UserContext db = new UserContext())
                {
                    //MessageBox.Show("kykykyk22");
                    AllUsersApplications = new ObservableCollection<UserApplication>();
                    AllUsersApplications.Clear();
                    //MessageBox.Show("kykykyk23");
                    foreach (UserApplication u in db.UserApplications)
                    {
                        AllUsersApplications.Add(u);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.ToString());
            }
        }
        public void AllShipTemplates_Update()
        {
            try
            {
                //MessageBox.Show("kykykyk31");
                using (UserContext db = new UserContext())
                {
                    //MessageBox.Show("kykykyk32");
                    AllShipTemplates = new ObservableCollection<ShipTemplate>();
                    AllShipTemplates.Clear();
                    //MessageBox.Show("kykykyk33 ");
                    //MessageBox.Show("kykykyk33 " + db.ShipTemplates.ToString());
                    foreach (ShipTemplate ST in db.ShipTemplates)
                    {
                        //MessageBox.Show(ST.ToString());
                        AllShipTemplates.Add(ST);
                    }
                    //MessageBox.Show("kykykyk34");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.ToString());
            }
        }

        public void SelectedRout_list_Update(List<Button> list)
        {
            SelectedRout_list = new ObservableCollection<Rout>();
            SelectedRout_list.Clear();
            if (list.Count < 2) return;
            for (int i = 1; i < list.Count;i++)
            {
                Rout r = new Rout(list[i - 1].Name, list[i].Name, 0, 0, 0, CurrentShipTemplate);
                SelectedRout_list.Add(r);
            }
        }


        private RelayCommand getResult;
        public RelayCommand GetResult
        {
            get
            {
                return getResult ??
                    (getResult = new RelayCommand(obj =>
                    {
                        //AllShipTemplates.Clear();
                        //AllShipTemplates.Add(new ShipTemplate { Name="1231"});
                        //AllShipTemplates_Update();
                        //AllShipTemplates = new ObservableCollection<ShipTemplate>();
                        //view_MainWindow.DockPanel.Text = CurrentShipTemplate.ToString();
                        //if (SelectedRout_list.Count>0)
                        //foreach(Rout r in SelectedRout_list)
                        //{
                        //    MessageBox.Show(r.Start_City + " -> " + r.End_City + " - " + r.Wind_Speed.ToString() + " - " + r.Flow_Speed.ToString());
                        //}


                        //if (checkParametrs())
                        //{
                        //    //MessageBox.Show(SelectedRout_list.Count().ToString());
                        //    double sum = 0;
                        //    if (SelectedRout_list!=null)
                        //    foreach (Rout r in SelectedRout_list)
                        //    {
                        //        sum+=RouteCalculation.getFuelExpenses(r, CurrentShipTemplate);
                        //    }
                        //    MessageBox.Show(sum.ToString());
                        //}

                        //MessageBox.Show(SelectedRout_list[0].RoutParts[0].Length.ToString());

                        //MessageBox.Show(view_MainWindow.selectedArrow)

                        MessageBox.Show(((Rout)view_MainWindow.grid_TowCabels.SelectedItem).Start_City);

                    }));
            }
        }

        public bool checkParametrs()
        {
            if (CurrentShipTemplate.Stroke_Index1 == 0) { MessageBox.Show("Введите нагруженность судна"); return false; }
            if (CurrentShipTemplate.Stroke_Index2 == 0) { MessageBox.Show("Введите длину судна"); return false; }
            if (CurrentShipTemplate.Stroke_Index3 == 0) { MessageBox.Show("Введите высоту судна"); return false; }
            if (CurrentShipTemplate.Stroke_Index4 == 0) { MessageBox.Show("Введите Осадку судна"); return false; }
            if (CurrentShipTemplate.Parking_Index1 == 0) { MessageBox.Show("Введите мощьность двигателя"); return false; }
            if (CurrentShipTemplate.Parking_Index2 == 0) { MessageBox.Show("Введите Удельный расход топлива"); return false; }
            if (CurrentShipTemplate.Parking_Index3 == 0) { MessageBox.Show("Введите мин скорость судна"); return false; }
            if (CurrentShipTemplate.Parking_Index4 == 0) { MessageBox.Show("Введите макс скорость судна"); return false; }
            return true;
        }



        private RelayCommand addUserCommand;
        public RelayCommand AddUserCommand
        {
            get
            {
                return addUserCommand ??
                    (addUserCommand = new RelayCommand(obj =>
                    {
                        ProfileWindow profWin = new ProfileWindow(new User(), true);
                        profWin.Owner = view_MainWindow;
                        profWin.ShowDialog();

                    }));
            }
        }

        private RelayCommand userDoubleClick;
        public RelayCommand UserDoubleClick
        {
            get
            {
                return userDoubleClick ??
                    (userDoubleClick = new RelayCommand(obj =>
                    {
                        if (selectedUser == null) return;
                        ProfileWindow profWin = new ProfileWindow(selectedUser,false);
                        profWin.Owner = view_MainWindow;
                        profWin.ShowDialog();
                    }));
            }
        }

        private RelayCommand userApplicationDoubleClick;
        public RelayCommand UserApplicationDoubleClick
        {
            get
            {
                return userApplicationDoubleClick ??
                    (userApplicationDoubleClick = new RelayCommand(obj =>
                    {
                        if (selectedUserApplication == null) return;
                        ProfileWindow profWin = new ProfileWindow(selectedUserApplication);
                        profWin.Owner = view_MainWindow;
                        profWin.ShowDialog();
                    }));
            }
        }


        private RelayCommand deleteSelectedUserApplication;
        public RelayCommand DeleteSelectedUserApplication
        {
            get
            {
                return deleteSelectedUserApplication ??
                    (deleteSelectedUserApplication = new RelayCommand(obj =>
                    {
                        if (selectedUserApplication == null) return;
                            DeleteUserApplication(selectedUserApplication);
                    }));
            }
        }


        private RelayCommand deleteSelectedUser;
        public RelayCommand DeleteSelectedUser
        {
            get
            {
                return deleteSelectedUser ??
                    (deleteSelectedUser = new RelayCommand(obj =>
                    {
                        if (currentUser == null) return;
                        DeleteUser(selectedUser);
                        
                    }));
            }
        }

        private RelayCommand makeUserFromApplication;
        public RelayCommand MakeUserFromApplication
        {
            get
            {
                return makeUserFromApplication ??
                    (makeUserFromApplication = new RelayCommand(obj =>
                    {
                        if (selectedUserApplication == null) return;
                        AddNewUser(new User { Name = selectedUserApplication.Name, Pass = selectedUserApplication.Pass, DocNumber = selectedUserApplication.DocNumber });
                        DeleteUserApplication(selectedUserApplication);
                        AllUsers_Update();
                        AllUsersApplications_Update();
                    }));
            }
        }

        
        public void ChangeShipTemplate(int ID)
        {
            foreach (ShipTemplate ST in AllShipTemplates)
            {
                if (ST.Id == ID)
                {
                    CurrentShipTemplate.SetValues(ST);
                }
            }
        }
        public void SaveNewShipTemplate()
        {
            //view_MainWindow.Stroke_Index1.Text = "++++++";
            SetNewShipTemplateName SetNewName = new SetNewShipTemplateName();
            SetNewName.Owner = view_MainWindow;
            if (SetNewName.ShowDialog() == true)
            {
                using(UserContext db = new UserContext())
                {
                    ShipTemplate s = new ShipTemplate();
                    s.SetValues(CurrentShipTemplate);
                    db.ShipTemplates.Add(s);
                    db.SaveChanges();
                }
            }
            AllShipTemplates_Update();
        }
        public void DeleteCurrentShipTemplate()
        {
            //view_MainWindow.Stroke_Index1.Text = "++++++";
            using (UserContext db = new UserContext())
            { 
                foreach(ShipTemplate ST in db.ShipTemplates)
                {
                    if (ST.Id == CurrentShipTemplate.Id)
                        db.ShipTemplates.Remove(ST);
                }
                db.SaveChanges();
                CurrentShipTemplate = new ShipTemplate();
                SetBindings bindings = new SetBindings();
                bindings.SetBindingForCurrentShipTemplate(view_MainWindow, CurrentShipTemplate);
                AllShipTemplates_Update();
            }
        }

        public void ChangeCurrentShipTemplate()
        {
            //view_MainWindow.Stroke_Index1.Text = "++++++";
            using (UserContext db = new UserContext())
            {
                foreach (ShipTemplate ST in db.ShipTemplates)
                {
                    if (ST.Id == CurrentShipTemplate.Id)
                        ST.SetValues(CurrentShipTemplate);
                }
                db.SaveChanges();
            }
            AllShipTemplates_Update();
        }


        public void DeleteUser(User user)
        {
            if (user == null) return;
            using (UserContext db = new UserContext())
            {
                foreach(User u in db.Users)
                {
                    if (u.Id == user.Id)
                        db.Users.Remove(u);
                }
                db.SaveChanges();
                AllUsers_Update();
            }
        }

        public void DeleteUserApplication(UserApplication user)
        {
            if (user == null) return;
            using (UserContext db = new UserContext())
            {
                foreach (UserApplication u in db.UserApplications)
                {
                    if (u.Id == user.Id)
                        db.UserApplications.Remove(u);
                }
                db.SaveChanges();
                AllUsersApplications_Update();
            }
        }

        public void AddUserApplication(UserApplication user)
        {
            using (UserContext db = new UserContext())
            {
                db.UserApplications.Add(new UserApplication { Name = user.Name, Pass = user.Pass, DocNumber = user.DocNumber });
                db.SaveChanges();
            }
            AllUsersApplications_Update();
        }

        public void AddNewUser(User user)
        {
            using (UserContext db = new UserContext())
            {
                db.Users.Add(new User { Name = user.Name, Pass = user.Pass, DocNumber = user.DocNumber });
                db.SaveChanges();
            }
            AllUsers_Update();
        }

        


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
