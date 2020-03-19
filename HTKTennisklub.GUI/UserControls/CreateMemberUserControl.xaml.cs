using HTKTennisklub.DAL;
using HTKTennisklub.Entities;
using HTKTennisklub.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HTKTennisklub.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for CreateMemberUserControl.xaml
    /// </summary>
    public partial class CreateMemberUserControl : UserControl
    {
        public CreateMemberUserControl()
        {
            InitializeComponent();

            //for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 120; i--)
            //{
            //    birthYear.Items.Add(i);
            //}

            Gender[] genders = (Gender[])Enum.GetValues(typeof(Gender)).Cast<Gender>();
            string[] genderDescriptions = new string[genders.Length];
            for (int i = 0; i < genders.Length; i++)
            {
                genderDescriptions[i] = genders[i].GetDescription();
            }
            gender.ItemsSource = genderDescriptions;

            List<Level> levels = new LevelRepository().GetLevels();
            foreach (Level currentLevel in levels)
            {
                level.Items.Add(currentLevel.Name);
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            new MemberRepository().InsertMember(
            new Member()
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                Address = address.Text,
                PhoneNumber = phoneNumber.Text,
                Email = email.Text,
                BirthDate = birthDate.SelectedDate.GetValueOrDefault(),
                Gender = EnumDescription.GetValueFromDescription<Gender>(gender.Text),
                Level = new LevelRepository().GetLevel(level.Text)
            });
            Window.GetWindow(this).Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => Window.GetWindow(this).Close();
    }
}
